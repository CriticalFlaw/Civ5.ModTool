﻿using System.Collections.Generic;
using System.Xml.Serialization;

namespace CivModTool.Models.Civilization.CityNames
{
    [XmlRoot(ElementName = "Civilization_CityNames", Namespace = "CityNames")]
    public class Civilization_CityNames
    {
        [XmlElement(ElementName = "Row")]
        public List<CityNames> Row { get; set; }
    }

    [XmlRoot(ElementName = "Row")]
    public class CityNames
    {
        [XmlElement(ElementName = "CivilizationType")]
        public string CivilizationType { get; set; }

        [XmlElement(ElementName = "CityName")]
        public string CityName { get; set; }
    }
}