﻿// Copyright (c) Aspose 2002-2016. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace GroupDocsRedactionVisualStudioPlugin.Core
{
    public class GlobalData
    {
        public static bool isComponentFormAborted = false;
        public static bool isAutoOpened = true;
        public static string SelectedComponent = string.Empty;
        public static BackgroundWorker backgroundWorker;
    }
}
