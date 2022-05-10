var MyPlugin = {
    IsMobile: function()
    {
        return UnityLoader.SystemInfo.mobile;
    }
};

var OpenWindowPlugin = {
    openWindow: function(link)
    {
        var url = Pointer_stringify(link);
        window.open(url,"_self");
/*
        document.onmouseup = function()
        {
            window.open(url);
            document.onmouseup = null;
        }

        var url = Pointer_stringify(link);
        document.ontouchend = function()
        {
          window.open(url);
          document.ontouchend = null;
        }
*/

    }
};

var OpenWindowNewTabPlugin = {
    openWindowNewTab: function(link2)
    {
        var url2 = Pointer_stringify(link2);

        document.onmouseup = function()
        {
            window.open(url2);
            document.onmouseup = null;
        }

        var url2 = Pointer_stringify(link2);
        document.ontouchend = function()
        {
          window.open(url2);
          document.ontouchend = null;
        }

    }
};

mergeInto(LibraryManager.library, MyPlugin);
mergeInto(LibraryManager.library, OpenWindowPlugin);
mergeInto(LibraryManager.library, OpenWindowNewTabPlugin);
