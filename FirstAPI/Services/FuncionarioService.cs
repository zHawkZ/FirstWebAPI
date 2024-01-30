using FirstAPI.DataContext;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;
using Exception = System.Exception;

namespace FirstAPI.Services;

public  class FuncionarioService : IFuncionarioInterface
{
    private readonly ApplicationDbContext _context;
    
    public FuncionarioService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            serviceResponse.Dados = _context.Funcionarios.ToList();
            if (serviceResponse.Dados.Count == 0)
                serviceResponse.Message = "Nenhum dado encontrado";
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            if (novoFuncionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Message = "Informar dados!";
                serviceResponse.Sucesso = false;
            }
            _context.Add(novoFuncionario);
            await _context.SaveChangesAsync();

            serviceResponse.Dados = _context.Funcionarios.ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
    {
        ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();
        try
        {
            FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Message = "Funcionario nao encontrado";
                serviceResponse.Sucesso = false;
            }else
                serviceResponse.Dados = funcionario;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel funcionarioEditado)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == funcionarioEditado.Id);
            if (funcionarioEditado == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Message = "Informar dados!";
                serviceResponse.Sucesso = false;
            }
            else
            {
                funcionarioEditado.DataDeCriacao = funcionario.DataDeCriacao;
                funcionarioEditado.DataDeAtualizacao = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(funcionarioEditado);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

        try
        {
            FuncionarioModel funcionarioADeletar = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
            if (funcionarioADeletar == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Message = "Funcionario nao encontrado";
                serviceResponse.Sucesso = false;
            }
            else
            {
                _context.Remove(funcionarioADeletar);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Message = "Funcionario nao encontrado";
                serviceResponse.Sucesso = false;
            }
            else
            {
                funcionario.IsAtivo = false;
                funcionario.DataDeAtualizacao = DateTime.Now.ToLocalTime();
                _context.Update(funcionario);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Funcionarios.ToList();
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }
}