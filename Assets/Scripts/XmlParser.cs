using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using UnityEngine;

class XmlParser
{
    static XDocument doc;

    public static string GetTextFromXml(int level, int phraseId)
    {
        if (doc == null)
            doc = XDocument.Load(Path.Combine(Application.streamingAssetsPath, "Texts.xml"));

        XElement root = doc.Element("Texts");
        foreach (var element in root.Elements("Text"))
        {
            if (element.Attribute("lvl").Value == level.ToString())
            {
                foreach (var e in element.Elements("Phrase"))
                {
                    if (e.Attribute("id").Value == phraseId.ToString())
                        return e.Value;
                }
            }
        }

        return "";

    }
}

