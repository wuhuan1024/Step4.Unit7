using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Step4.Unit7.Model;
using Step4.Unit7.Service;
using Step4.Unit7.Service.Dto;
using Step4.Unit7.Service.Dto.condition;
using Step4.Unit7.Service.utils;
using X.PagedList;

namespace Step4.Unit7.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    // GET
    public IActionResult Index(AccountRequest? request = null)
    {
        ViewBag.StateList = EnumHelper.ToDescriptionDictionary<AccountStateEnum>().Select(
            p => new SelectListItem
            {
                Text = p.Value,
                Value = p.Key.ToString()
            });
        var list = _accountService.Search(request);
        var pageModel = new StaticPagedList<AccountViewModel>(list, request.PageIndex, request.PageSize, request.Total);
        return View(pageModel);
    }

    public IActionResult Add()
    {
      
        ViewBag.DebtorList = new SelectList(_accountService.GetDebtor(), "Id", "NickName");
        return View();
    }

    [HttpPost]
    public IActionResult SubmitAdd(AccountBo bo)
    {
        if (ModelState.IsValid)
        {
            _accountService.Add(bo);
            return RedirectToAction("Index");
        }

        ViewBag.DebtorList = new SelectList(_accountService.GetDebtor(), "Id", "NickName");
        return View("Add", bo);
    }

    public IActionResult Edit(long id)
    {
        ViewBag.StateList = EnumHelper.ToDescriptionDictionary<AccountStateEnum>().Select(
            p => new SelectListItem
            {
                Text = p.Value,
                Value = p.Key.ToString()
            });
        return View( _accountService.GetModel(id));
    }
    [HttpPost]
    public IActionResult SubmitUpdate(AccountUpdateBo bo)
    {
        if (ModelState.IsValid)
        {
            _accountService.Update(bo); 
            return RedirectToAction("Index");
        }
        ViewBag.DebtorList = new SelectList(_accountService.GetDebtor(), "Id", "NickName");
        return View("Edit", bo);
    }
    
    public IActionResult Delete(long id)
    {
        _accountService.Delete(id);
        return RedirectToAction("Index");
    } 
   
}
