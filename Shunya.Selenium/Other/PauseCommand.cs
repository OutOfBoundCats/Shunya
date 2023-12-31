// Author:- raj
// Github:- @OutOfBoundCats
// Created At:- 16/11/2023/2:26 pm

using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using Shunya.Selenium.ExecutionEngine;

namespace Shunya.Selenium.Other;

public static class PauseCommand
{

    /// <summary>
    /// Pauses execution indefinitely resumes after browser window is closed. <br/>
    ///  Only For <b> debugging </b> purpose
    /// </summary>
    /// <param name="skip">whether to skip the pause</param>
    /// <returns>IChainable</returns>
    public static IChainable<T> Pause<T>(this IChainable<T> chain,bool skip=false)
    {
        bool stop = false;
        ILogger l = chain.GetLogger();
        var driver = chain.GetDriver();
        if (!skip)
        {
            l.LogInformation("Paused execution.Waiting for window close");
            string originalWindow = driver.CurrentWindowHandle;
            driver.SwitchTo().NewWindow(WindowType.Window);
            IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
            js.ExecuteScript("document.body.innerHTML='<div>Execution is paused.Please close this window to continue execution.</div>'");
            string pauseWindow = driver.CurrentWindowHandle;
            bool isClosed = false;
            while (!isClosed)
            {
                var a =driver.WindowHandles.Where(x => x == pauseWindow);
                if (a.Count() == 0)
                {
                    isClosed = true;
                }
            }
            driver.SwitchTo().Window(originalWindow);
        }
        ActionTaskResult<T> actionResult = new ActionTaskResult<T>(ref chain.GetContext(),chain.GetResult());
        return actionResult;
    }
}