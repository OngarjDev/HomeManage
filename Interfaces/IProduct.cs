using InsureManage.Models;

namespace InsureManage.Interfaces
{
    public interface IProduct
    {
        /// <summary>
        /// สำหรับเพิ่มข้อมูล ProductService ลงในฐานข้อมูล
        /// </summary>
        /// <param name="product">รับข้อมูล ProductService</param>
        /// <returns>หากเป็นจริงข้อมูลถูกบันทึกแล้ว หากไม่เป็นจริงมีปัญหาในการส่งข้อมูลไปยัง Database</returns>
        Task<bool> AddProduct(Product product);
        /// <summary>
        /// ดึงข้อมูลสินค้าทั้งหมดออกมาทั้งหมด
        /// </summary>
        /// <returns>ข้อมูลสินค้าทั้งหมดที่อยู่ในฐานข้อมูลออกมา</returns>
        Task<List<Product>> GetDataListProduct();
        /// <summary>
        /// แก้ไขข้อมูล ProductService 
        /// </summary>
        /// <param name="product"></param>
        /// <returns>หากเป็นจริงข้อมูลถูกบันทึกแล้ว หากไม่เป็นจริงมีปัญหาในการส่งข้อมูลไปยัง Database</returns>
        Task<bool> UpdateProduct(Product product);
        /// <summary>
        /// ลบข้อมูลเฉพาะ ProductService ที่ต้องการลบ ด้วย Id
        /// </summary>
        /// <param name="id_product">Id_Product ที่ต้องการลบ</param>
        /// <returns>หากเป็นจริงข้อมูลถูกลบแล้ว หากไม่เป็นจริงมีปัญหาในการลบข้อมูล</returns>
        Task<bool> DeleteProduct(int id_product);
        /// <summary>
        /// ค้นหาข้อมูลที่เกี่ยวข้องทั้งหมดแล้วส่งข้อมูลที่เกี่ยวข้องกลับมา
        /// </summary>
        /// <param name="product">รับ Product ที่มีข้อมูลที่เกี่ยวข้องเพื่อค้นหา</param>
        /// <returns>ส่งข้อมูลที่มีความเกี่ยวข้องทั้งหมด</returns>
        Task<List<Product>> SearchProduct(Product product);
    }
}
