using FirstAPI.Models;

namespace FirstAPI.Services;

public interface IFuncionarioInterface
{
    Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();

    Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel? novoFuncionario);
    
    Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);
    
    Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel funcionarioEditado);
    
    Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);
    
    Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id);
}