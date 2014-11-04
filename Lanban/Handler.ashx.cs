﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Threading;
using System.Web.SessionState;


namespace Lanban
{
    /// <summary>
    /// Async handler for request from client
    /// </summary>
    public class Handler : IHttpAsyncHandler, IReadOnlySessionState //IRequiresSessionState
    {
        public bool IsReusable { get { return false; } }

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback callback, Object state)
        {
            HandlerOperation operation = new HandlerOperation(callback, context, state);
            operation.QueueWork();
            return operation;
        }

        public void EndProcessRequest(IAsyncResult result)
        {

        }

        public void ProcessRequest(HttpContext context)
        {
            throw new InvalidOperationException();
        }
    }
}