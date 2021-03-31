---
id: features-overview
url: redaction/net/features-overview
title: Features Overview
weight: 1
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
## Document Redaction Tool

GroupDocs.Redaction is a quality redaction software, providing a single format-independent interface for redacting sensitive and classified information from the PDF, Word, Excel, PowerPoint documents and images, including the ability to change metadata and remove comments. With GroupDocs.Redaction tool you can redact text and save redacted document in PDF, transforming all pages into raster images or keep the document in its original format for further editing.

Choosing the most appropriate redaction mode depends on your reasons to sanitize the classified information from the document. Let’s review in detail what are the differences between rasterization and saving in original format and how to choose the most suitable for your case.  

#### Rasterization

You can black out parts of PDF or other supported document type with our redaction toolkit and create a new PDF file with raster images of redacted document's pages. The sanitized document contains no searchable text, no metadata from the original document. At the same time, annotations (comments, badges,etc.) remain visible - but not clickable. You can use DeleteAnnotationRedaction to delete all comments in the document.

Rasterization is the best option to choose if:  

*   you have to conform regulations of authorities, requesting PDF as a format;
    
*   you have a PDF file as an original format;  
    
*   you need to pass the document to third parties;
*   you need this document to be opened on different platforms.  
    

For all these cases rasterization is the right option.

#### Keeping Original Format

GroupDocs.Redaction toolkit can save the document in its original format after the redactions were applied.

Keeping original format is the best option to choose if:  

*   you need to continue working and editing this document in its original application bring sure that all sensitive data were removed;
    
*   you have to pass this document to someone else in your company for editing, but without sensitive data;
    
*   you need to pass the document to third parties, like contractors, but hide your sensitive information.  
    

#### Spreadsheet Redactions

A special case of keeping original format is redacting spreadsheets with data. With GroupDocs.Redaction you can set the scope of a single worksheet or even a column on it to limit textual redactions only to this scope. In this case a regular expression will be matched only in a given scope, not the entire document.

#### Metadata Redactions

Saving the document in an original format requires deleting or redacting its metadata to remove all sensitive information. For these purposes GroupDocs.Redaction provides metadata redactions.

#### Annotation Redactions

Annotation redactions allow you to remove specific or any annotations (comments, badges, etc.) from the document. You can use regular expressions to match annotations you need to redact out.

## Image Redactions

With GroupDocs.Redaction OCR support, you can extract a text from an image, search it for data and redact sensitive data within the image. As an alternative, you can put a colored box over a given area, such as header, footer, or an area, where customer's data are expected to appear. Also you can use it to edit exif data or use it as an exif eraser.

You can use GroupDocs.Redaction to redact all kinds of embedded images within a document:

*   Redact each page of a PDF file, created from paper page scans;

*   Create a rasterized PDF file, and edit its pages as images;

*   Redact all images within a PDF, Microsoft Office or Open Office document.
