
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using WebAppGestor.Interface;
using WebAppGestor.Models;

namespace WebAppGestor.Controllers 
{
    public class GestaoController : Controller
    {
        private readonly ICliente _cliente;
        


        public GestaoController(ICliente cliente)
        {
            _cliente = cliente;
            
        }


        //--------------------------    CLIENTE     ---------------------------------------


        // GET: GestaoController
        public ActionResult Index()
        {
            //
            return View(_cliente.Listar());
        }

        // GET: GestaoController/Details/5
        public ActionResult Details(int id)
        {
            Detalhe detalhe = new Detalhe();
            

            detalhe.Cliente = _cliente.ObterClientePorId(id);
            
            detalhe.Contato = _cliente.ObterContatoPorIdCliente(id);
            
            detalhe.Endereco = _cliente.ObterEnderecoPorIdCliente(id);
            

            return View(detalhe);
        }

        // GET: GestaoController/Create
        public ActionResult CreateCliente ()
        {
            return View();
        }

        // POST: GestaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente (Cliente cliente)
        {
            try
            {
                var clienteCriado = _cliente.AddCliente(cliente);
                ViewBag.id = clienteCriado.ClienteId;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

         //GET: GestaoController/Edit/5
        public ActionResult EditCliente(int id)
        {


            return View(_cliente.ObterClientePorId(id));
        }

        // POST: GestaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCliente(Cliente cliente)
        {
            try
            {
                _cliente.UpdateCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DeleteCliente (int id)
        {   
                        
            _cliente.RemoveCliente(id);            
            return RedirectToAction(nameof(Index));
                      
        }

        
     



        //---------------------     CONTATO     ---------------------------------


        public ActionResult CreateContato(int id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: GestaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateContato(Contato contato)
        {
            try
            {
                
                var contatoCriado = _cliente.AddContato(contato);
                
                ViewBag.id = contatoCriado.ClienteId;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditContato(int id)
        {
            if(id== 0)
            {
                return RedirectToAction(nameof(Index));
            }
                
            return View(_cliente.ObterContatoPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditContato(Contato contato)
        {
            try
            {
                _cliente.UpdateContato(contato);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteContato(int id)
        {
            //_cliente.RemoveContato(id);
            //return RedirectToAction(nameof(Index));
            return View(_cliente.ObterContatoPorId(id));
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteContato (int id, Contato contato)
        {
            try
            {
                _cliente.RemoveContato(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        //-------------------------     ENDERECO        ----------------------------------------

        public ActionResult CreateEndereco (int id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: GestaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEndereco (Endereco endereco)
        {
            try
            {

                _cliente.AddEndereco(endereco);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        

        public ActionResult EditEndereco (int id)
        {

             if(id== 0)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(_cliente.ObterEnderecoPorId(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEndereco (Endereco endereco)
        {
            try
            {
                _cliente.UpdateEndereco(endereco);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteEndereco (int id)
        {
             //_cliente.RemoveEndereco(id);
             return View(_cliente.ObterEnderecoPorId(id));
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEndereco(int id, Endereco endereco)
        {
            try
            {
                _cliente.RemoveEndereco(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
