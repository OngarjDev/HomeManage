using InsureManage.Models;

namespace InsureManage.Interfaces
{
    public interface IPosition
    {
        /// <summary>
        /// ค้นหาตำแหน่งที่ตั้งแบบเฉพาะเจาะจง
        /// </summary>
        /// <param name="IdPositio">ใส่ข้อมูลข้อมูล Id ที่ต้องการค้นหา</param>
        /// <returns>หากทำสำเร็จจะเป็น True หากทำไม่สำเร็จจะเป็น False</returns>
        Task<List<Position>> GetByIdPositionAsync(int IdPositio);
        /// <summary>
        /// ดึงตำแหน่งที่เก็บของภายในบ้านทั้งหมด
        /// </summary>
        /// <returns>ให้ข้อมูลตำแหน่งทั้งหมดเป็น List </returns>
        Task<List<Position>> GetAllPositionAsync();
        /// <summary>
        /// เพิ่มข้อมูลลงในฐานข้อมูล
        /// </summary>
        /// <param name="position">ใส่ข้อมูลทั้งหมดที่ต้องการเพิ่ม</param>
        /// <returns>หากทำสำเร็จจะเป็น True หากทำไม่สำเร็จจะเป็น False</returns>
        Task<bool> AddPositionAsync(Position position);
        /// <summary>
        /// ลบตำแหน่งที่เก็บของ
        /// </summary>
        /// <param name="IdPosition">รับค่า IdPosition หรือ Id ของที่ตั้ง</param>
        /// <returns>หากทำสำเร็จจะเป็น True หากทำไม่สำเร็จจะเป็น False</returns>
        Task<bool> RemovePositionAsync(int IdPosition);
        /// <summary>
        /// สำหรับกรณีย้อยที่เก็บของไปยังที่ใหม่ จะได้ไม่ต้องแก้ที่ฐานข้อมูล
        /// </summary>
        /// <param name="position">ข้อมูลใหม่ที่จะ อัพเดตลงในฐานข้อมูล</param>
        /// <returns>หากทำสำเร็จจะเป็น True หากทำไม่สำเร็จจะเป็น False</returns>
        Task<bool> MovePositionAsync(Position position);
    }
}
