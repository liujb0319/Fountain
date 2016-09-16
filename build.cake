var target = Argument("target", "default");

Task("default")
    .Does(() => {
        DotNetBuild("./Fountain.sln", settings =>
        settings.SetConfiguration("Release")
            .SetVerbosity(Verbosity.Minimal));
    });

RunTarget(target);