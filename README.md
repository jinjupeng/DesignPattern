# 设计模式



## 设计原则（SOLID）

+ SRP（单一职责原则）
+ OCP（开闭原则）
+ LSP（里氏替换原则）
+ ISP（接口隔离原则）
+ DIP（依赖倒置原则）

其它设计原则：DRY 原则、KISS 原则、YAGNI 原则、LOD 法则



## 设计模式

### 创建型模式

> **创建型模式**提供创建对象的机制， 增加已有代码的灵活性和可复用性

　　**① 01.单例（Singleton）模式**

　　**② 02.简单工厂（Simple Factory）模式**

　　**③ 03.工厂方法（Factory Method）模式**

　　**④ 04.抽象工厂（Abstract Factory）模式**

　　⑤ 05.原型（Prototype）模式

　　⑥ 06.建造者（Builder）模式

### 结构型模式

> **结构型模式**介绍如何将对象和类组装成较大的结构， 并同时保持结构的灵活和高效

　　**① 07.适配器（Adapter）模式**

　　**② 08.桥接（Bridge）模式**

　　③ 09.组合（Composite）模式

　　**④ 10.装饰（Decorator）模式**

　　⑤ 11.外观（Facade）模式

　　⑥ 12.享元（Flyweight）模式

　　**⑦ 13.代理（Proxy）模式**

### 行为型模式

> **行为模式**负责对象间的高效沟通和职责委派

　　**① 14.职责链（Chain of Responsibility）模式**

　　**② 15.观察者（Observer）模式**

　　③ 16.访问者（Visitor）模式

　　**④ 17.模板方法（Template Method）模式**

　　**⑤ 18.策略（Strategy）模式**

　　⑥ 19.命令（Command）模式

　　⑦ 20.备忘录（Memento）模式

　　**⑧ 21.迭代器（Iterator）模式**

　　⑨ 22.中介者（Mediator）模式

　　⑩ 23.解释器（Interpreter）模式



## UML图

虚线箭头指向依赖；
实线箭头指向关联；
虚线三角指向接口；
实线三角指向父类；
空心菱形能分离而独立存在，是聚合；
实心菱形精密关联不可分，是组合；