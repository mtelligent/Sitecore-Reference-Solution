module.exports = function () {
  var instanceRoot = "C:\\Websites\\reference.dev.local";
  var config = {
    websiteRoot: instanceRoot,
    sitecoreLibraries: instanceRoot + "\\bin",
    licensePath: instanceRoot + "\\App_Data\\license.xml",
    solutionName: "TraceLogger",
    buildConfiguration: "Debug",
    buildPlatform: "Any CPU",
    buildToolsVersion: 15.0, //change to 15.0 for VS2017 support
    publishPlatform: "AnyCpu",
    runCleanBuilds: false
  };
  return config;
}
