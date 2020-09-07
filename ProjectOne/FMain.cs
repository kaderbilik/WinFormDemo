using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectOne
{
    public partial class FMain : Form
    {
        List<Category> categoryList = new List<Category>();
        List<Product> urunListesi = new List<Product>();
        public FMain()
        {
            InitializeComponent();
        }
        #region form load olayı

        private void FMain_Load(object sender, EventArgs e)
        {



            VerileriDoldur(categoryList, urunListesi);


            cbxCategory.DataSource = categoryList;
            cbxCategory.DisplayMember = "Name";
            cbxCategory.ValueMember = "Id";

            dgwProduct.DataSource = urunListesi;



        }
        #endregion

        #region verileri listlere doldurma

        private static void VerileriDoldur(List<Category> categoryList, List<Product> urunListesi)
        {
            var category1 = new Category()
            {
                Name = "Yiyecek",
                Id = 1

            };
            var category2 = new Category()
            {
                Name = "İçecek",
                Id = 2

            };

            categoryList.Add(category1);
            categoryList.Add(category2);



            var urun = new Product()
            {
                Name = "Domates",
                UnitPrice = 15,
                CategoryId = 1,
                Id = 1

            };
            urunListesi.Add(urun);
            var urun2 = new Product()
            {
                Name = "Meyve Suyu",
                UnitPrice = 20,
                CategoryId = 2,
                Id = 2

            };
            urunListesi.Add(urun2);

            var urun3 = new Product()
            {
                Name = "Coca Cola",
                UnitPrice = 30,
                CategoryId = 2,
                Id = 3

            };
            urunListesi.Add(urun3);

            var urun4 = new Product()
            {
                Name = "Cips",
                UnitPrice = 40,
                CategoryId = 1,
                Id = 4

            };
            urunListesi.Add(urun4);
        }


        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            var urunAdi = txtName.Text.Trim();
            var urunFiyati = Convert.ToDecimal(txtUnitPrice.Text.Trim());
            var categoryId = Convert.ToInt32(cbxCategory.SelectedValue.ToString());

            var urunId = dgwProduct.RowCount + 1;


            var product = new Product
            {
                Name = urunAdi,
                UnitPrice = urunFiyati,
                CategoryId = categoryId,
                Id = urunId
            };

            urunListesi.Add(product);

            dgwProduct.DataSource = null;
            dgwProduct.Refresh();
            dgwProduct.DataSource = urunListesi;


        }
    }
}
