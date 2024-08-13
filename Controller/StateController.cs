using System.Data;
using EventApi.Context;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class StateController : ControllerBase
{
    private readonly MyService _myService;

    public StateController(MyService myService)
    {
        _myService = myService;
    }

    //C
    [HttpPost]
    [Route("newstate")]
    public dynamic newState([FromBody] Estado? State = null){
        bool nulo = State == null;
        string st = "";
        Object? result = null;
        //Console.WriteLine("RECIVIENDO...");
        if(!nulo){
            bool vacio = State?.Nombre == null & State?.Id == 0;
            if(!vacio){
                string sql = "INSERT INTO dbo.Estado (id,nombre) VALUES ("+State?.Id+",'"+State?.Nombre+"');";
                _myService.EjecutarNoReturn(sql);
                st = "OK";
                result = State;
            }else{
                st = "VOID";
            }
            
        }else{
            st = "NULL";
        }
        return new {
            estado = st,
            resultado = result
        };
    }
    //R
    [HttpPost]
    [Route("getallstates")]
    public IActionResult GetAllStates(){
        string sql = "SELECT * FROM dbo.Estado;";
        var dataTable = _myService.Ejecutar(sql);
        return Ok(ConvertDataTableToDictionary(dataTable));
    }
    
    [HttpPost]
    [Route("getstates")]
    public IActionResult GetStates([FromBody] Estado State){
        string sql = $"SELECT * FROM dbo.Estado WHERE id={State.Id};";
        var dataTable = _myService.Ejecutar(sql);
        return Ok(ConvertDataTableToDictionary(dataTable));
    }

    private List<Dictionary<string, object>> ConvertDataTableToDictionary(DataTable dataTable)
    {
        var result = new List<Dictionary<string, object>>();

        foreach (DataRow row in dataTable.Rows)
        {
            var dict = new Dictionary<string, object>();

            foreach (DataColumn column in dataTable.Columns)
            {
                dict[column.ColumnName] = row[column];
            }

            result.Add(dict);
        }

        return result;
    }
    //U
    //D
}