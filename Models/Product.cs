using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;

namespace Demo2704.Models;

public partial class Product
{
    public int Productid { get; set; }

    public string? Productarticlenumber { get; set; }

    public string? Productname { get; set; }

    public string? Productdescription { get; set; }

    public int? Productcategoryid { get; set; }

    public string? Productphoto { get; set; }

    public int? Productmanufacturerid { get; set; }

    public decimal? Productcost { get; set; }

    public int? Productdiscountamount { get; set; }

    public int? Productquantityinstock { get; set; }

    public bool? Productstatus { get; set; }

    public virtual ICollection<Orderproduct> Orderproducts { get; set; } = new List<Orderproduct>();

    public virtual Category? Productcategory { get; set; }

    public virtual Manufacturer? Productmanufacturer { get; set; }

    public Bitmap ImageBitmap
    {
        get
        { if(Productphoto != null && Productphoto != "")
            {
                Bitmap bitmap = new Bitmap(Path.Combine(Directory.GetCurrentDirectory().Replace("bin\\Debug\\net10.0", "Resources"), Productphoto));
                return bitmap;
            }
            else
            {
                Bitmap bitmap = new Bitmap(Path.Combine(Directory.GetCurrentDirectory().Replace("bin\\Debug\\net10.0", "Resources"), "picture.png"));
                return bitmap;
            }
        }
    }
}
