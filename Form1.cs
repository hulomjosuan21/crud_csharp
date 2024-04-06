using HulomJosuan.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HulomJosuan
{
    public partial class Form1 : Form
    {
        hulomdbEntities _context = new hulomdbEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            var result = _context.Categories.ToList();

            categoryBindingSource.DataSource = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category newCategory = new Category();

            newCategory.CategoryName = textBox1.Text.Trim();

            _context.Categories.Add(newCategory);
            _context.SaveChanges();

            var result = _context.Categories.ToList();

            categoryBindingSource.DataSource = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = _context.Categories
                .Where(q => q.CategoryName.Contains(textBox2.Text.Trim()))
                .ToList();

            categoryBindingSource.DataSource = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string getId = textBox3.Text.Trim();
            var itemToDelete = _context.Categories.Where(q => q.Id.ToString() == getId).FirstOrDefault();

            _context.Categories.Remove(itemToDelete);
            _context.SaveChanges();

            categoryBindingSource.DataSource = _context.Categories.ToList();
        }
    }
}
