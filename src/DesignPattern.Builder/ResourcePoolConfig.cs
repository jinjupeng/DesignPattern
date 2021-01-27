using System;

namespace DesignPattern.Builder
{
    public class ResourcePoolConfig
    {
        private readonly string name;
        private readonly int maxTotal;
        private readonly int maxIdle;
        private readonly int minIdle;

        /// <summary>
        /// 设置为私有的，无法直接实例化ResourcePoolConfig类
        /// </summary>
        /// <param name="builder"></param>
        private ResourcePoolConfig(Builder builder)
        {
            this.name = builder.name;
            this.maxTotal = builder.maxTotal;
            this.maxIdle = builder.maxIdle;
            this.minIdle = builder.minIdle;
        }

        public void Test()
        {
            Console.WriteLine(name);
        }

        //我们将Builder类设计成了ResourcePoolConfig的内部类。
        //我们也可以将Builder类设计成独立的非内部类ResourcePoolConfigBuilder。
        public class Builder
        {
            private static readonly int DEFAULT_MAX_TOTAL = 8;
            private static readonly int DEFAULT_MAX_IDLE = 8;
            private static readonly int DEFAULT_MIN_IDLE = 0;

            public string name;
            public int maxTotal = DEFAULT_MAX_TOTAL;
            public int maxIdle = DEFAULT_MAX_IDLE;
            public int minIdle = DEFAULT_MIN_IDLE;

            public ResourcePoolConfig build()
            {
                // 校验逻辑放到这里来做，包括必填项校验、依赖关系校验、约束条件校验等
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException("...");
                }
                if (maxIdle > maxTotal)
                {
                    throw new ArgumentException("...");
                }
                if (minIdle > maxTotal || minIdle > maxIdle)
                {
                    throw new ArgumentException("...");
                }

                return new ResourcePoolConfig(this);
            }

            public Builder setName(string name)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException("...");
                }
                this.name = name;
                return this;
            }

            public Builder setMaxTotal(int maxTotal)
            {
                if (maxTotal <= 0)
                {
                    throw new ArgumentException("...");
                }
                this.maxTotal = maxTotal;
                return this;
            }

            public Builder setMaxIdle(int maxIdle)
            {
                if (maxIdle < 0)
                {
                    throw new ArgumentException("...");
                }
                this.maxIdle = maxIdle;
                return this;
            }

            public Builder setMinIdle(int minIdle)
            {
                if (minIdle < 0)
                {
                    throw new ArgumentException("...");
                }
                this.minIdle = minIdle;
                return this;
            }
        }
    }
}
