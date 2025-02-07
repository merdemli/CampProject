﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;   //_products; tüm metotların dışında, class'ın içinde tanımlanan değişkenlere GLOBAL DEĞİŞKEN denir
                                   //ve _products şeklinde yazılır
        public InMemoryProductDal()

        {     //Oracle,SqlServer gibi DB'lerden geliyormuş gibi simule ediyoruz

            _products = new List<Product> {
                new Product{ProductId=1, CategoryId=1, ProductName= "Bardak",UnitPrice=15, UnitsInStock=15},
                new Product{ProductId=2, CategoryId=2, ProductName= "Kamera",UnitPrice=500,UnitsInStock= 3},
                new Product{ProductId=3, CategoryId=2, ProductName= "Telefon",UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName= "Klavye",UnitPrice=150, UnitsInStock=65},
                new Product{ProductId=5, CategoryId=2, ProductName= "Fare",UnitPrice=85, UnitsInStock=1},
            };
         }


        public void Add(Product product)
        {
            _products.Add(product);   //UI'dan , business'a, business katmanından gönderilen ürünü DB'ye yani inmemory çalıştığımız için Liste'ye ekliyoruz
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            // Lambda
                                                               //her p için
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);

            // foreach'i yapıyor  //id olan aramalarda genelde   singleOrDefault kullanırız
        }                                           //product döndürür


        public List<Product> GetAll() //burada business ürün listesini istediğinde, tüm Listeyi, yani Db'yi döndürürsün. 
        {
            return _products;
        }


        public void Update(Product product) //güncel ürün gönderildi,bunu veri kaynağında güncellemek istiyoruz
        {   
            //gönderdiğim ürün id'sine sahip olan listedeki ürünü bul 
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //productToUpdate listedeki elemanın referansı olmuş olur, bulunca
            //veri kaynağındaki referans   //veri kaynağını güncelliyoruz.
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId; 
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }                                 //gönderdiğim product

        public List<Product> GetAllByCategory(int categoryId) //ürünleri kategori id'sine göre listele, örn 2 olanları listele
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); //LINQ
                             //şarta uyanları tablo yapıp getirir
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }

}
