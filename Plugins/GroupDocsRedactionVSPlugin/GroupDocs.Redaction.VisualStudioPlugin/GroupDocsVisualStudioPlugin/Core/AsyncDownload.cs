﻿// Copyright (c) Aspose 2002-2016. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupDocsRedactionVisualStudioPlugin.Core
{
   public  class AsyncDownload
    {
        GroupDocsComponent _component;

        public GroupDocsComponent Component
        {
            get { return _component; }
            set { _component = value; }
        }
        private string _url;

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        private string _localPath;

        public string LocalPath
        {
            get { return _localPath; }
            set { _localPath = value; }
        }
    }
}
