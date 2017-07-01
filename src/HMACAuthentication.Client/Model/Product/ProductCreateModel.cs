using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace HMACAuthentication.Client.Model.Product
{
    public class ProductCreateModel
    {

        public class ProductData
        {

            public string Megapixels { get; set; }
            public string OpticalZoom { get; set; }
            public string SystemMemory { get; set; }
            public string NumberCpus { get; set; }
            public string Network { get; set; }
            public string Clasp { get; set; }
            public string ColorFamily { get; set; }
            public string Gender { get; set; }
            public string InnerSoleMaterial { get; set; }
            public string SeasonWear { get; set; }
            public string SizeScaleMp { get; set; }
            public string SoleMaterial { get; set; }
            public string Style { get; set; }
            public string Subset { get; set; }
            public string UpperMaterial { get; set; }
            public string ModelName { get; set; }
            public string Print { get; set; }
 
        }

        [XmlRoot(ElementName = "Product")]
        public class Product
        {
            [XmlElement(ElementName = "SellerSku")]
            public string SellerSku { get; set; }
            [XmlElement(ElementName = "ParentSku")]
            public string ParentSku { get; set; }
            [XmlElement(ElementName = "Status")]
            public string Status { get; set; }
            [XmlElement(ElementName = "Name")]
            public string Name { get; set; }
            [XmlElement(ElementName = "Variation")]
            public string Variation { get; set; }
            [XmlElement(ElementName = "PrimaryCategory")]
            public string PrimaryCategory { get; set; }
            [XmlElement(ElementName = "Categories")]
            public string Categories { get; set; }
            [XmlElement(ElementName = "Description")]
            public string Description { get; set; }
            [XmlElement(ElementName = "Brand")]
            public string Brand { get; set; }
            [XmlElement(ElementName = "Price")]
            public string Price { get; set; }
            [XmlElement(ElementName = "SalePrice")]
            public string SalePrice { get; set; }
            [XmlElement(ElementName = "SaleStartDate")]
            public string SaleStartDate { get; set; }
            [XmlElement(ElementName = "SaleEndDate")]
            public string SaleEndDate { get; set; }
            [XmlElement(ElementName = "TaxClass")]
            public string TaxClass { get; set; }
            [XmlElement(ElementName = "ShipmentType")]
            public string ShipmentType { get; set; }
            [XmlElement(ElementName = "ProductId")]
            public string ProductId { get; set; }
            [XmlElement(ElementName = "Condition")]
            public string Condition { get; set; }
            [XmlElement(ElementName = "ProductData")]
            public ProductData ProductData { get; set; }
            [XmlElement(ElementName = "Quantity")]
            public string Quantity { get; set; }
        }

        [XmlRoot(ElementName = "Request")]
        public class Request
        {
            [XmlElement(ElementName = "Product")]
            public Product Product { get; set; }
        }

    }


}


