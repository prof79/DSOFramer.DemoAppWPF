// Interop.cs

namespace DSOFramer.DemoApps
{
    using System;
    using System.Runtime.InteropServices;

    internal class Interop
    {
        internal enum PROCESS_DPI_AWARENESS : UInt32
        {
            PROCESS_DPI_UNAWARE = 0,
            PROCESS_SYSTEM_DPI_AWARE = 1,
            PROCESS_PER_MONITOR_DPI_AWARE = 2
        }

        internal enum HRESULT : UInt32
        {
            S_OK = 0x00000000,
            E_FAIL = 0x80004005,
            E_ACCESSDENIED = 0x80070005,
            E_INVALIDARG = 0x80070057
        }

        /// <summary>
        /// Win32 API for process-scoped DPI-awareness.
        /// Available since Windows Vista.
        /// </summary>
        /// <returns>True if successful, false otherwise.</returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool SetProcessDPIAware();

        /// <summary>
        /// Newer Win32 API for process-scoped DPI-awareness
        /// including awareness-context (Windows 8.1 or higher).
        /// </summary>
        /// <returns>
        /// Either S_OK (= 0), E_INVALIDARG or E_ACCESSDENIED.
        /// </returns>
        [DllImport("shcore.dll", SetLastError = true)]
        internal static extern HRESULT SetProcessDpiAwareness(
            PROCESS_DPI_AWARENESS awareness
        );
    }
}
