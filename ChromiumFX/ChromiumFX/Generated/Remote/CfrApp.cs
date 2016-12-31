// Copyright (c) 2014-2015 Wolfgang Borgsmüller
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions 
// are met:
// 
// 1. Redistributions of source code must retain the above copyright 
//    notice, this list of conditions and the following disclaimer.
// 
// 2. Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution.
// 
// 3. Neither the name of the copyright holder nor the names of its 
//    contributors may be used to endorse or promote products derived 
//    from this software without specific prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE 
// COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, 
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, 
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS 
// OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND 
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR 
// TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

// Generated file. Do not edit.


using System;

namespace Chromium.Remote {
    using Event;

    /// <summary>
    /// Implement this structure to provide handler implementations. Methods will be
    /// called by the process and/or thread indicated.
    /// </summary>
    /// <remarks>
    /// See also the original CEF documentation in
    /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
    /// </remarks>
    public class CfrApp : CfrClientBase {

        internal static CfrApp Wrap(RemotePtr remotePtr) {
            if(remotePtr == RemotePtr.Zero) return null;
            var weakCache = CfxRemoteCallContext.CurrentContext.connection.weakCache;
            lock(weakCache) {
                var cfrObj = (CfrApp)weakCache.Get(remotePtr.ptr);
                if(cfrObj == null) {
                    cfrObj = new CfrApp(remotePtr);
                    weakCache.Add(remotePtr.ptr, cfrObj);
                }
                return cfrObj;
            }
        }



        private CfrApp(RemotePtr remotePtr) : base(remotePtr) {}
        public CfrApp() : base(new CfxAppCtorWithGCHandleRemoteCall()) {
            RemotePtr.connection.weakCache.Add(RemotePtr.ptr, this);
        }

        /// <summary>
        /// Provides an opportunity to view and/or modify command-line arguments before
        /// processing by CEF and Chromium. The |ProcessType| value will be NULL for
        /// the browser process. Do not keep a reference to the CfrCommandLine
        /// object passed to this function. The CfrSettings.CommandLineArgsDisabled
        /// value can be used to start with an NULL command-line object. Any values
        /// specified in CfrSettings that equate to command-line arguments will be set
        /// before this function is called. Be cautious when using this function to
        /// modify command-line arguments for non-browser processes as this may result
        /// in undefined behavior including crashes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public event CfrOnBeforeCommandLineProcessingEventHandler OnBeforeCommandLineProcessing {
            add {
                if(m_OnBeforeCommandLineProcessing == null) {
                    var call = new CfxAppSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnBeforeCommandLineProcessing += value;
            }
            remove {
                m_OnBeforeCommandLineProcessing -= value;
                if(m_OnBeforeCommandLineProcessing == null) {
                    var call = new CfxAppSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 0;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnBeforeCommandLineProcessingEventHandler m_OnBeforeCommandLineProcessing;


        /// <summary>
        /// Provides an opportunity to register custom schemes. Do not keep a reference
        /// to the |Registrar| object. This function is called on the main thread for
        /// each process and the registered schemes should be the same across all
        /// processes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public event CfrOnRegisterCustomSchemesEventHandler OnRegisterCustomSchemes {
            add {
                if(m_OnRegisterCustomSchemes == null) {
                    var call = new CfxAppSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_OnRegisterCustomSchemes += value;
            }
            remove {
                m_OnRegisterCustomSchemes -= value;
                if(m_OnRegisterCustomSchemes == null) {
                    var call = new CfxAppSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 1;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrOnRegisterCustomSchemesEventHandler m_OnRegisterCustomSchemes;


        /// <summary>
        /// Return the handler for resource bundle events. If
        /// CfrSettings.PackLoadingDisabled is true (1) a handler must be returned.
        /// If no handler is returned resources will be loaded from pack files. This
        /// function is called by the browser and render processes on multiple threads.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public event CfrGetResourceBundleHandlerEventHandler GetResourceBundleHandler {
            add {
                if(m_GetResourceBundleHandler == null) {
                    var call = new CfxAppSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_GetResourceBundleHandler += value;
            }
            remove {
                m_GetResourceBundleHandler -= value;
                if(m_GetResourceBundleHandler == null) {
                    var call = new CfxAppSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 2;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrGetResourceBundleHandlerEventHandler m_GetResourceBundleHandler;


        /// <summary>
        /// Return the handler for functionality specific to the render process. This
        /// function is called on the render process main thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public event CfrGetRenderProcessHandlerEventHandler GetRenderProcessHandler {
            add {
                if(m_GetRenderProcessHandler == null) {
                    var call = new CfxAppSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 4;
                    call.active = true;
                    call.RequestExecution(RemotePtr.connection);
                }
                m_GetRenderProcessHandler += value;
            }
            remove {
                m_GetRenderProcessHandler -= value;
                if(m_GetRenderProcessHandler == null) {
                    var call = new CfxAppSetCallbackRemoteCall();
                    call.self = RemotePtr.ptr;
                    call.index = 4;
                    call.active = false;
                    call.RequestExecution(RemotePtr.connection);
                }
            }
        }

        internal CfrGetRenderProcessHandlerEventHandler m_GetRenderProcessHandler;


    }

    namespace Event {

        /// <summary>
        /// Provides an opportunity to view and/or modify command-line arguments before
        /// processing by CEF and Chromium. The |ProcessType| value will be NULL for
        /// the browser process. Do not keep a reference to the CfrCommandLine
        /// object passed to this function. The CfrSettings.CommandLineArgsDisabled
        /// value can be used to start with an NULL command-line object. Any values
        /// specified in CfrSettings that equate to command-line arguments will be set
        /// before this function is called. Be cautious when using this function to
        /// modify command-line arguments for non-browser processes as this may result
        /// in undefined behavior including crashes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnBeforeCommandLineProcessingEventHandler(object sender, CfrOnBeforeCommandLineProcessingEventArgs e);

        /// <summary>
        /// Provides an opportunity to view and/or modify command-line arguments before
        /// processing by CEF and Chromium. The |ProcessType| value will be NULL for
        /// the browser process. Do not keep a reference to the CfrCommandLine
        /// object passed to this function. The CfrSettings.CommandLineArgsDisabled
        /// value can be used to start with an NULL command-line object. Any values
        /// specified in CfrSettings that equate to command-line arguments will be set
        /// before this function is called. Be cautious when using this function to
        /// modify command-line arguments for non-browser processes as this may result
        /// in undefined behavior including crashes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public class CfrOnBeforeCommandLineProcessingEventArgs : CfrEventArgs {

            private CfxOnBeforeCommandLineProcessingRemoteEventCall call;

            internal string m_process_type;
            internal bool m_process_type_fetched;
            internal CfrCommandLine m_command_line_wrapped;

            internal CfrOnBeforeCommandLineProcessingEventArgs(CfxOnBeforeCommandLineProcessingRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the ProcessType parameter for the <see cref="CfrApp.OnBeforeCommandLineProcessing"/> render process callback.
            /// </summary>
            public string ProcessType {
                get {
                    CheckAccess();
                    if(!m_process_type_fetched) {
                        m_process_type = call.process_type_str == IntPtr.Zero ? null : (call.process_type_length == 0 ? String.Empty : CfrRuntime.Marshal.PtrToStringUni(new RemotePtr(call.process_type_str), call.process_type_length));
                        m_process_type_fetched = true;
                    }
                    return m_process_type;
                }
            }
            /// <summary>
            /// Get the CommandLine parameter for the <see cref="CfrApp.OnBeforeCommandLineProcessing"/> render process callback.
            /// </summary>
            public CfrCommandLine CommandLine {
                get {
                    CheckAccess();
                    if(m_command_line_wrapped == null) m_command_line_wrapped = CfrCommandLine.Wrap(new RemotePtr(call.command_line));
                    return m_command_line_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("ProcessType={{{0}}}, CommandLine={{{1}}}", ProcessType, CommandLine);
            }
        }

        /// <summary>
        /// Provides an opportunity to register custom schemes. Do not keep a reference
        /// to the |Registrar| object. This function is called on the main thread for
        /// each process and the registered schemes should be the same across all
        /// processes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public delegate void CfrOnRegisterCustomSchemesEventHandler(object sender, CfrOnRegisterCustomSchemesEventArgs e);

        /// <summary>
        /// Provides an opportunity to register custom schemes. Do not keep a reference
        /// to the |Registrar| object. This function is called on the main thread for
        /// each process and the registered schemes should be the same across all
        /// processes.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public class CfrOnRegisterCustomSchemesEventArgs : CfrEventArgs {

            private CfxOnRegisterCustomSchemesRemoteEventCall call;

            internal CfrSchemeRegistrar m_registrar_wrapped;

            internal CfrOnRegisterCustomSchemesEventArgs(CfxOnRegisterCustomSchemesRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Get the Registrar parameter for the <see cref="CfrApp.OnRegisterCustomSchemes"/> render process callback.
            /// </summary>
            public CfrSchemeRegistrar Registrar {
                get {
                    CheckAccess();
                    if(m_registrar_wrapped == null) m_registrar_wrapped = CfrSchemeRegistrar.Wrap(new RemotePtr(call.registrar));
                    return m_registrar_wrapped;
                }
            }

            public override string ToString() {
                return String.Format("Registrar={{{0}}}", Registrar);
            }
        }

        /// <summary>
        /// Return the handler for resource bundle events. If
        /// CfrSettings.PackLoadingDisabled is true (1) a handler must be returned.
        /// If no handler is returned resources will be loaded from pack files. This
        /// function is called by the browser and render processes on multiple threads.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public delegate void CfrGetResourceBundleHandlerEventHandler(object sender, CfrGetResourceBundleHandlerEventArgs e);

        /// <summary>
        /// Return the handler for resource bundle events. If
        /// CfrSettings.PackLoadingDisabled is true (1) a handler must be returned.
        /// If no handler is returned resources will be loaded from pack files. This
        /// function is called by the browser and render processes on multiple threads.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public class CfrGetResourceBundleHandlerEventArgs : CfrEventArgs {

            private CfxGetResourceBundleHandlerRemoteEventCall call;


            internal CfrResourceBundleHandler m_returnValue;
            private bool returnValueSet;

            internal CfrGetResourceBundleHandlerEventArgs(CfxGetResourceBundleHandlerRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Set the return value for the <see cref="CfrApp.GetResourceBundleHandler"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfrResourceBundleHandler returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
            }
        }

        /// <summary>
        /// Return the handler for functionality specific to the render process. This
        /// function is called on the render process main thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public delegate void CfrGetRenderProcessHandlerEventHandler(object sender, CfrGetRenderProcessHandlerEventArgs e);

        /// <summary>
        /// Return the handler for functionality specific to the render process. This
        /// function is called on the render process main thread.
        /// </summary>
        /// <remarks>
        /// See also the original CEF documentation in
        /// <see href="https://bitbucket.org/chromiumfx/chromiumfx/src/tip/cef/include/capi/cef_app_capi.h">cef/include/capi/cef_app_capi.h</see>.
        /// </remarks>
        public class CfrGetRenderProcessHandlerEventArgs : CfrEventArgs {

            private CfxGetRenderProcessHandlerRemoteEventCall call;


            internal CfrRenderProcessHandler m_returnValue;
            private bool returnValueSet;

            internal CfrGetRenderProcessHandlerEventArgs(CfxGetRenderProcessHandlerRemoteEventCall call) { this.call = call; }

            /// <summary>
            /// Set the return value for the <see cref="CfrApp.GetRenderProcessHandler"/> render process callback.
            /// Calling SetReturnValue() more then once per callback or from different event handlers will cause an exception to be thrown.
            /// </summary>
            public void SetReturnValue(CfrRenderProcessHandler returnValue) {
                if(returnValueSet) {
                    throw new CfxException("The return value has already been set");
                }
                m_returnValue = returnValue;
                returnValueSet = true;
            }
        }

    }
}