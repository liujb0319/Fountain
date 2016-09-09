var target = Argument("target", "default");

Task("default")
    .Does(() => {
        DotNetBuild("./Fountain.sln");
    });

RunTarget(target);