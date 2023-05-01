function WindowWidth() {
    return window.innerWidth;
}

window.addEventListener('resize', function () {
    DotNet.invokeMethodAsync("InsureManage", "OnWindowResize",WindowWidth())
});