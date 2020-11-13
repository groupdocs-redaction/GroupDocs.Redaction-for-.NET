---
id: spreadsheet-redactions
url: redaction/net/spreadsheet-redactions
title: Spreadsheet redactions
weight: 8
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
GroupDocs.Redaction allows to remove sensitive or private data from your XLS, XLSX, ODS spreadsheet document formats and others. See full list at [supported document formats]({{< ref "redaction/net/getting-started/supported-document-formats.md" >}}) article.

## Filter by spreadsheet and column

If you have a document with one or more tables, organized into worksheets (one table per worksheet) - such as Microsoft Excel documents - you can use specific type of textual redactions, [CellColumnRedaction](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.redactions/cellcolumnredaction). It allows you to set the scope of the redaction to a specific worksheet and/or column. The options are:

*   optionally set worksheet name or its numeric index (if both are missing, redaction affects all worksheets)
*   optionally set column (all columns are used, if the column filter is not set)

If no filters are set, redactions affects the entire document. All indices are zero-based. Below is an example, where we use all filters, to redact second column with emails (e.g. loaded from database) on a worksheet "Customers", leaving untouched all other emails in the document:

**C#**

```csharp
using (Redactor redactor = new Redactor("D:\\Sales in September.xslx"))
{
   var filter = new CellFilter()
   {
      ColumnIndex = 1, // zero-based 2nd column
      WorkSheetName = "Customers"
   };
   var expression = new Regex("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$");
   RedactorChangeLog changeLog = redactor.Apply(new CellColumnRedaction(filter, expression, new ReplacementOptions("[customer email]")));
   if (result.Status != RedactionStatus.Failed)
   {
      doc.Save(new SaveOptions() { AddSuffix = true });
   };
}
```

## More resources

### Advanced usage topics

To learn more about document redaction features, please refer to the [advanced usage section]({{< ref "redaction/net/developer-guide/advanced-usage/_index.md" >}}).

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Redaction for .NET examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET)
    
*   [GroupDocs.Redaction for Java examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-Java)
    

### Free online document redaction App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to perform redactions for various document formats like PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Redaction App](https://products.groupdocs.app/redaction).
