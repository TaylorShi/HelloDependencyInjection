## 为什么需要依赖注入框架

![](/Assets/375390-20220902092105561-1442610962.png)

* 借助依赖注入框架，可以轻松管理类之间的依赖，帮助我们在构建应用时遵循设计原则，确保代码的可维护性和可扩展性。
* ASP.NET Core的整个架构中，依赖注入框架提供了对象创建和生命周期管理的核心能力，各个组件相互协作，也是依靠依赖注入框架的能力来实现的。

## 组件包

* [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection)
* [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions)

它采用**接口实现分离**模式，其中`Microsoft.Extensions.DependencyInjection.Abstractions`是抽象包，`Microsoft.Extensions.DependencyInjection`是具体实现。

意味着后续我们可以用第三方包来替代默认实现。

## 核心类型

* `IServiceCollection`，负责服务的注册。
* `ServiceDescriptor`，每一个服务注册时的信息。
* `IServiceProvider`，具体的容器，也是由`ServiceCollection` Build出来的。
* `IServiceScope`，表示一个容器的子容器的生命周期。

## 生命周期(Sevice Lifetime)

* `单例(Singleton)`，指在整个根容器的生命周期内，都是单例，不管你是根容器还是子容器。
* `作用域(Scoped)`，在容器的生存周期内，或者子容器的生存周期内，如果我的容器释放掉，意味着我的对象也会释放掉，在这个范围内我们得到的是个单例模式。
* `瞬时(暂时)Transient`，指我们每一次从容器中获取对象时，都可以得到一个全新的对象。

> 单例和作用域的区别是，单例是全局的单例，作用域是范围内的单例。

## 相关文章

* [乘风破浪，遇见最佳跨平台跨终端框架.Net Core/.Net生态 - 贯穿ASP.NET Core整个架构的依赖注入框架(Dependency Injection)](https://www.cnblogs.com/taylorshi/p/16648649.html)