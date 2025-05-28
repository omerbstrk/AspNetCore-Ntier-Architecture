using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper.Result;
using Repository.Abstract;
using ServiceHelper.Abstract;
using ServiceHelper.Ticket.ServiceHelper;

namespace ServiceHelper.Concrete
{
    public class Service<T, DTO> : IService<T, DTO> where T : class where DTO : class
    {
        private readonly IRepository<T> _repository;
        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<Result<bool>> Delete(int id)
        {
            Result<bool> response = new();
            try
            {
                T entity = await _repository.GetById(id);
                if (entity == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Veri Bulunamadı";
                }
                else
                {
                    await _repository.Delete(entity);
                    response.Data = true;
                    response.Message = "Veriler Başarıyla Silindi.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
        public async Task<Result<DTO>> GetById(int id)
        {
            Result<DTO> response = new();
            try
            {
                T entity = await _repository.GetById(id);
                DTO dto = Mapping.Mapper.Map<DTO>(entity);
                if (dto == null) return new Result<DTO>(false, "Veri Bulunamadı");
                response.Data = dto;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
        public async Task<Result<bool>> Insert(DTO entity)
        {
            Result<bool> response = new();
            try
            {
                T EntityToAdd = Mapping.Mapper.Map<T>(entity);
                await _repository.Insert(EntityToAdd);
                response.Data = true;
                response.Message = "Veri Başarıyla Eklendi";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
        public async Task<Result<List<DTO>>> List()
        {
            Result<List<DTO>> response = new();
            try
            {
                List<T> entities = await _repository.List();
                List<DTO> dtos = Mapping.Mapper.Map<List<DTO>>(entities);
                response.Data = dtos;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
        public async Task<Result<bool>> Update(DTO entity)
        {
            Result<bool> response = new();

            try
            {
                T EntityToUpdate = Mapping.Mapper.Map<T>(entity);
                await _repository.Update(EntityToUpdate);
                response.Data = true;
                response.Message = "Veriler Başarıyla Güncellendi";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;

        }
        public async Task<Result<bool>> status(int id)
        {
            Result<bool> response = new();
            try
            {
                bool entity = await _repository.Status(id);
                response.Data = entity;
                response.Message = entity ? "İşlem Başarılı Bir Şekilde Tamamlandı." : "Kategori Bulunamadı veya Durum Güncellenemedi";
                response.Success = entity;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
