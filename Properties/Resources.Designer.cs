﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.34014
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Samples.Kinect.DiscreteGestureBasics.Properties {
    using System;
    
    
    /// <summary>
    ///   用於查詢當地語系化字串等的強類型資源類別。
    /// </summary>
    // 這個類別是自動產生的，是利用 StronglyTypedResourceBuilder
    // 類別透過 ResGen 或 Visual Studio 這類工具。
    // 若要加入或移除成員，請編輯您的 .ResX 檔，然後重新執行 ResGen
    // (利用 /str 選項)，或重建您的 VS 專案。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   傳回這個類別使用的快取的 ResourceManager 執行個體。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Samples.Kinect.DiscreteGestureBasics.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   覆寫目前執行緒的 CurrentUICulture 屬性，對象是所有
        ///   使用這個強類型資源類別的資源查閱。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查詢類似 Not Tracked 的當地語系化字串。
        /// </summary>
        public static string Body_NotTracked {
            get {
                return ResourceManager.GetString("Body_NotTracked", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查詢類似 Failed to write screenshot to {0} 的當地語系化字串。
        /// </summary>
        public static string FailedScreenshotStatusTextFormat {
            get {
                return ResourceManager.GetString("FailedScreenshotStatusTextFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查詢類似 No ready Kinect found! 的當地語系化字串。
        /// </summary>
        public static string NoSensorStatusText {
            get {
                return ResourceManager.GetString("NoSensorStatusText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查詢類似 Running 的當地語系化字串。
        /// </summary>
        public static string RunningStatusText {
            get {
                return ResourceManager.GetString("RunningStatusText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查詢類似 Kinect not available! 的當地語系化字串。
        /// </summary>
        public static string SensorNotAvailableStatusText {
            get {
                return ResourceManager.GetString("SensorNotAvailableStatusText", resourceCulture);
            }
        }
    }
}
