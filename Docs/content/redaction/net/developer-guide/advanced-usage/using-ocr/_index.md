---
id: using-ocr
url: redaction/net/using-ocr
title: Using OCR to redact image documents
weight: 1
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---

GroupDocs.Redaction supports both types of image documents for Optical Character Recognition (OCR):
*   image files, such as printed document scans (PNG, JPG, etc.)
*   embedded images within office documents (PDF, DOCX, etc.)  

You have to implement [IOcrConnector](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.integration.ocr/iocrconnector) interface and pass the instance to [RedactorSettings](https://apireference.groupdocs.com/net/redaction/groupdocs.redaction.options/redactorsettings) constructor.

For more details, see [OCR Usage Basics]({{< ref "redaction/net/developer-guide/advanced-usage/using-ocr/ocr-usage-basics" >}}) article.

## OCR usage limitations

There are the following limitations of the OCR with GroupDocs.Redaction v21.3:
*   textual replacements are not supported, so you have to use color box replacements to redact text in images.
*   Spreadsheets, HTML and Markdown document types are not supported.  

We are working on removing these limitations in future releases of GroupDocs.Redaction.

## Learn more

You can find details and examples of using OCR with GroupDocs.Redaction in one of these guides:
