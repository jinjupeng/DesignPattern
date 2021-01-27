using System;

namespace DesignPattern.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            // 这段代码会抛出IllegalArgumentException，因为minIdle>maxIdle
            ResourcePoolConfig config = new ResourcePoolConfig.Builder() 
                .setName("dbconnectionpool") 
                .setMaxTotal(16) 
                .setMaxIdle(15) 
                .setMinIdle(12) 
                .build();
            config.Test();
            Console.ReadLine();
        }
    }
}
