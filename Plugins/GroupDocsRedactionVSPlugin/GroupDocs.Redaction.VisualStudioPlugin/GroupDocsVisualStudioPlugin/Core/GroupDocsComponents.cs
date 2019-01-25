// Copyright (c) Aspose 2002-2016. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GroupDocsRedactionVisualStudioPlugin.Core
{
    public class GroupDocsComponents
    {
        public static Dictionary<String, GroupDocsComponent> list = new Dictionary<string, GroupDocsComponent>();
        public GroupDocsComponents()
        {
            list.Clear();

            GroupDocsComponent groupdocsRedaction = new GroupDocsComponent();
            groupdocsRedaction.set_downloadUrl("");
            groupdocsRedaction.set_downloadFileName("groupdocs.Redaction.zip");
            groupdocsRedaction.set_name(Constants.GROUPDOCS_COMPONENT);
            groupdocsRedaction.set_remoteExamplesRepository("https://github.com/groupdocs-Redaction/GroupDocs.Redaction-for-.NET.git");
            list.Add(Constants.GROUPDOCS_COMPONENT, groupdocsRedaction);
        }
    }
}
