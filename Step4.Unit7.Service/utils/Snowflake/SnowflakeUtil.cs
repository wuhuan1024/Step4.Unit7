using Snowflake;

namespace Step4.Unit7.Service.utils.Snowflake
{
    /// <summary>
    /// Snowflake辅助类,利用IP生成Idworker
    /// </summary>
    public static class SnowflakeUtil
    {
        private static readonly object LockMac = new object();
        /// <summary>
        /// 过期秒数
        /// </summary>
        private static long _workId;
        private static IdWorker? _idWorker;
        

        /// <summary>
        /// 单例模式，创建IdWorker
        /// </summary>
        /// <returns>IdWorker实例</returns>
        public static IdWorker CreateIdWorker()
        {
            if (_idWorker == null)
            {
                lock (LockMac)
                {
                    if (_idWorker == null)
                    {
                        _workId = GetWorkId();
                        _idWorker = new IdWorker(_workId,0);
                       
                    }
                }
            }
            return _idWorker;
        }
        
        // redis 中存储当前最大的workerId值，以解决workerId重复问题
        private static int GetWorkId()
        {
            // // 因为是在静态类中，所以无法使用注入方式提供对象，只能自己实例化对象
            // IDistributedCache redis = new RedisCache(new RedisCacheOptions
            // {
            //     Configuration = "localhost:6379"
            // });
            int workerId = 0;
            // string maxWorkerId = redis.GetString("max_worker_id");
            // if (!string.IsNullOrWhiteSpace(maxWorkerId))
            // {
            //     workerId = Convert.ToInt32(maxWorkerId)+1;
            // }
            //
            // redis.SetString("max_worker_id",workerId.ToString());
            
            return workerId;
        }

    }
}
