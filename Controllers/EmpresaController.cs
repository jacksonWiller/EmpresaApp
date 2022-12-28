#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmpresaApp.Data;
using EmpresaApp.Models;
using EmpresaApp.Services;

namespace EmpresaApp.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly DataContext _context;

        public EmpresaController(DataContext context)
        {
            _context = context;
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empresas.ToListAsync());
        }

        // GET: Transaction/AddOrEdit
        public IActionResult Detalhes(int id = 0)
        {
            return View(_context.Empresas.Include(e => e.Funcionarios).Where(x => x.Id == id).FirstOrDefault());
        }


        // GET: Transaction/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Empresa());
            else
                return View(_context.Empresas.Include(e => e.Funcionarios).Where(x => x.Id == id).FirstOrDefault());
        }

        // POST: Transaction/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Nome,Cep,NumeroResidencial,Endereco,Telefone")] Empresa empresa)
        {
             EnderecoServices enderecoServices = new EnderecoServices();
             var Endereco = await enderecoServices.Integracao(empresa.Cep);
            Console.WriteLine(Endereco);
            if (ModelState.IsValid)
            {
                if (empresa.Id == 0)
                {
                    _context.Add(empresa);
                }
                else
                    _context.Update(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        // GET: Transaction/AddOrEdit
        public IActionResult Add(int id)
        {
            return View(new Empresa());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,Nome,Cep,NumeroResidencial,ComplementoEndereco,Telefone")] Empresa empresa)
        {
             //EnderecoServices enderecoServices = new EnderecoServices();
             //var Endereco = await enderecoServices.Integracao(empresa.Cep);
            //Console.WriteLine(Endereco);
           
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(empresa);
        }


        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empresa =  _context.Empresas.Where(x => x.Id == id).FirstOrDefault();
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    
        public IActionResult AddFuncionario(int empresaId)
        {
            var func = new Funcionario();
            func.EmpresaId = empresaId;
            return View(func);
        }

        [HttpPost, ActionName("AddFuncionario")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFuncionario([Bind("Id,Nome,Cargo,Salario")] Funcionario funcionario)
        {
             //EnderecoServices enderecoServices = new EnderecoServices();
             //var Endereco = await enderecoServices.Integracao(empresa.Cep);
            //Console.WriteLine(Endereco);
           
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(funcionario);
        }
    }
}
