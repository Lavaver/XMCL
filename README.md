"# XMCL" 
# XMCL（Xiaolian Minecraft Launcher）


这是一个由一群爱好者衍生出的启动器，

其实吧...这启动器拖了大约好几个月才重新立项开发（也算是卡时间的脖子了）

对于枫乔（唯一开发者）来说可是极为疼苦的几个月，不仅仅要重构成 WPF ，也要承受巨大压力（哭）

并且对于 Forge 等模组加载器版本不能顺利启动也很头疼...

不过，还是感谢你使用了这个启动器（或者你使用我们的源码对其完善改进使其变得更好），至少没辜负了我们的期待。

# 启动器有且只有唯一的特点

- 非常简洁

# 关于在软件中添加 Java 的解释

这其实是为了**偷懒而且方便部分玩家的举动**，但也因此导致包体很大。还请谅解。

并且对于这款启动器来说只能用相对路径定位（本作者没能力下的无奈之举），也不知道到哪个版本才是个头...

# （关于枫乔个人）写代码时发癫の片段

```csharp
StartGame_Info.Content = "正在启动游戏，请稍候";
            int secondsToWait = 5; 
            await Task.Delay(secondsToWait * 1000); // 这俩行代码我故意的（
```

```xml
<Label x:Name="NuGetText_KMCCC" Content="也特别感谢 KMCCC 库拯救了写 Minecraft 启动及登录的疼苦时刻（笑）" HorizontalAlignment="Left" Margin="32,345,0,0" VerticalAlignment="Top"/>
```

嘶...建议我们跳过这段（枫乔传统**在代码中发癫**）。