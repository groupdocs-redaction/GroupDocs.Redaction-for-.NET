---
id: use-redaction-policies
url: redaction/net/use-redaction-policies
title: Use redaction policies
weight: 4
description: ""
keywords: 
productName: GroupDocs.Redaction for .NET
hideChildren: False
---
If you have a corporate sensitive data removal policy as a list of redaction rules, you don't need to specify them in your code. You can specify an XML document with a list of pre-configured redactions.

Below is an example of redaction policy XML file (code properties mapping is obvious):

**RedactionPolicy.xml**

```csharp
<?xml version="1.0" encoding="utf-8"?>  
<redactionPolicy xmlns="http://www.groupdocs.com/redaction">  
  <regexRedaction regularExpression="(dolor)" actionType="ReplaceString" replacement="foobar" />  
  <exactPhraseRedaction searchPhrase="dolor" caseSensitive="true" actionType="DrawBox" color="Red" />   
  
  <cellColumnRedaction regularExpression="(foo)bar1" replacement="[red1]" columnIndex="1" worksheetIndex="2" /> 
  <cellColumnRedaction regularExpression="(foo)bar2" replacement="[red2]" wokrsheetName="Sample" /> 
  
  <eraseMetadataRedaction filter="All" />  
  <metadataSearchRedaction filter="Title, Author" replacement="foobar" valueExpression="(metasearch)" keyExpression="" />  
  
  <annotationRedaction regularExpression="(anno1)" replacement="foobar" />  
  <deleteAnnotationRedaction regularExpression="(anno2)" />  
  
  <imageAreaRedaction pointX="15" pointY="17" width="200" height="10" color="#AA50FC"  />  
  <imageAreaRedaction pointX="110" pointY="120" width="60" height="20" color="Magenta"  />  
</redactionPolicy> 
```
You can use RedactionPolicy.Save() method to create XML documents of this structure, configuring redactions in runtime.

The following example demonstrates how to save a [RedactionPolicy](https://apireference.groupdocs.com/redaction/net/groupdocs.redaction/redactionpolicy) to an XML file.
 
**C#**

```csharp
RedactionPolicy policy = new RedactionPolicy(new Redaction[] {
    new ExactPhraseRedaction("Redaction", new ReplacementOptions("[Product]")),
    new RegexRedaction("\\d{2}\\s*\\d{2}[^\\d]*\\d{6}", new ReplacementOptions(System.Drawing.Color.Blue)),
    new DeleteAnnotationRedaction(),
    new EraseMetadataRedaction(MetadataFilters.All)
});
policy.Save(".\\MyPolicyFile.xml");
```

You can have as much policies, as you need, loading them to redact your documents.

An example below shows how to apply redaction policy to all files within given inbound folder, and save to one of outbound folders - for successfully updated files and for failed ones. Current date and time is used as a part of output file name:

**C#**

```csharp
RedactionPolicy policy = RedactionPolicy.Load("RedactionPolicy.xml");
foreach (var fileEntry in Directory.GetFileNames("C:\\Inbound")) 
{
    using (Redactor redactor = new Redactor(Path.Combine("C:\\Inbound\\", fileEntry)))
	{
    	RedactorChangeLog result = redactor.Apply(policy);
        String resultFolder = result.Status != RedactionStatus.Failed ? "C:\\Outbound\\Done\\" : "C:\\Outbound\\Failed\\";
		using (Stream fileStream = File.Open(Path.Combine(resultFolder, fileEntry), FileMode.Open, FileAccess.ReadWrite))
   		{
      		redactor.Save(fileStream, new RasterizationOptions() { Enabled = false });
   		}        
	}
}   
```

## More resources

### GitHub examples

You may easily run the code above and see the feature in action in our GitHub examples:

*   [GroupDocs.Redaction for .NET examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-.NET)
    
*   [GroupDocs.Redaction for Java examples](https://github.com/groupdocs-redaction/GroupDocs.Redaction-for-Java)
    

### Free online document redaction App

Along with full featured .NET library we provide simple, but powerful free Apps.

You are welcome to perform redactions for various document formats like PDF, DOC, DOCX, PPT, PPTX, XLS, XLSX, Emails and more with our free online [Free Online Document Redaction App](https://products.groupdocs.app/redaction).
