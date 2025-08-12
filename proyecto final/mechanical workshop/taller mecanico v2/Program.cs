using System;
using workshop_manager_v2;

class Program
{
    static void Main(string[] args)
    {
        string opcionGeneral;

        do
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Gestión de Clientes");
            Console.WriteLine("2. Gestión de mecanicos");
            Console.WriteLine("3. Gestión de Vehículos");
            Console.WriteLine("4. Gestión de Reparaciones");
            Console.WriteLine("5. Gestión de Repuestos");
            Console.WriteLine("6. Gestión de Ventas");
            Console.WriteLine("7. Gestión de Vendedores");
            Console.WriteLine("8. Historial de Servicios");
            Console.WriteLine("9. final del dia ");
            Console.Write("Seleccione una opción: ");
            opcionGeneral = Console.ReadLine();

            switch (opcionGeneral)
            {
                case "2":
                    Console.WriteLine("1. Agregar mecánico");
                    Console.WriteLine("2. Ver todos los mecánicos");
                    Console.WriteLine("3. Ver mecánico por ID");
                    Console.WriteLine("4. Actualizar mecánico");
                    Console.WriteLine("5. Eliminar mecánico");
                    string opcionMecanico = Console.ReadLine();
                    switch (opcionMecanico)
                    {
                        case "1": try { MechanicService.Add(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { MechanicService.ViewAll(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { MechanicService.ViewById(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { MechanicService.Update(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { MechanicService.Delete(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "1":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE CLIENTES ===");
                    Console.WriteLine("1. Agregar cliente");
                    Console.WriteLine("2. Ver clientes");
                    Console.WriteLine("3. Ver por id");
                    Console.WriteLine("4. Actualizar cliente");
                    Console.WriteLine("5. Eliminar cliente");
                    Console.Write("Seleccione una opción: ");
                    string opcionCliente = Console.ReadLine();
                    switch (opcionCliente)
                    {
                        case "1": try { CustomerService.Add(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { CustomerService.View(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { CustomerService.ViewById(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { CustomerService.Update(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { CustomerService.Delete(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE VEHÍCULOS ===");
                    Console.WriteLine("1. Agregar vehículo");
                    Console.WriteLine("2. Ver vehículos");
                    Console.WriteLine("3. Ver por placa");
                    Console.WriteLine("4. Actualizar vehículo");
                    Console.WriteLine("5. Eliminar vehículo");
                    Console.Write("Seleccione una opción: ");
                    string opcionVehiculo = Console.ReadLine();
                    switch (opcionVehiculo)
                    {
                        case "1": try { VehicleService.Add(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { VehicleService.View(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { VehicleService.ViewByLicensePlate(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { VehicleService.Update(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { VehicleService.Delete(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE REPARACIONES ===");
                    Console.WriteLine("1. Agregar reparación");
                    Console.WriteLine("2. Ver reparaciones");
                    Console.WriteLine("3. Filtrar por fechas");
                    Console.WriteLine("4. Actualizar reparación");
                    Console.WriteLine("5. Eliminar reparación");
                    Console.Write("Seleccione una opción: ");
                    string opcionReparacion = Console.ReadLine();
                    switch (opcionReparacion)
                    {
                        case "1": try { RepairService.Add(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { RepairService.View(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { RepairService.FilterByDate(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { RepairService.Update(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { RepairService.Delete(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE REPUESTOS ===");
                    Console.WriteLine("1. Agregar repuesto");
                    Console.WriteLine("2. Ver repuestos");
                    Console.WriteLine("3. Actualizar repuesto");
                    Console.WriteLine("4. Eliminar repuesto");
                    Console.WriteLine("5. Ver historial de repuestos");
                    Console.Write("Seleccione una opción: ");
                    string opcionRepuesto = Console.ReadLine();
                    switch (opcionRepuesto)
                    {
                        case "1": try { SparePartService.Add(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { SparePartService.View(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { SparePartService.Update(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { SparePartService.Delete(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { SparePartService.ViewSparePartsHistory(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "6":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE VENTAS ===");
                    Console.WriteLine("1. Registrar venta");
                    Console.WriteLine("2. Ver todas las ventas");
                    Console.WriteLine("3. Ver venta por ID");
                    Console.WriteLine("4. Ver ventas filtradas (por cliente o fecha)");
                    Console.WriteLine("5. Actualizar venta");
                    Console.WriteLine("6.Eliminar");
                    Console.Write("Seleccione una opción: ");
                    string opcionVenta = Console.ReadLine();
                    switch (opcionVenta)
                    {
                        case "1": try { SalesService.AddSale(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { SalesService.ViewAll(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { SalesService.ViewById(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { SalesService.ViewSalesByDateRange(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { SalesService.Update(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "6": try { SalesService.Delete(); } catch (Exception ex) { Console.WriteLine(ex); } break;     
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "7":
                    Console.Clear();
                    Console.WriteLine("=== GESTIÓN DE VENDEDORES ===");
                    Console.WriteLine("1. Agregar vendedor");
                    Console.WriteLine("2. Ver vendedores");
                    Console.WriteLine("3. Actualizar vendedor");
                    Console.WriteLine("4. Eliminar vendedor");
                    Console.Write("Seleccione una opción: ");
                    string opcionVendedor = Console.ReadLine();
                    switch (opcionVendedor)
                    {
                        case "1": try { SalespersonService.Add(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "2": try { SalespersonService.ViewAll(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "3": try { SalespersonService.ViewById(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "4": try { SalespersonService.Update(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        case "5": try { SalespersonService.Delete(); } catch (Exception ex) { Console.WriteLine(ex); } break;
                        default: Console.WriteLine("Opción inválida."); break;
                    }
                    break;

                case "8":
                    try { MechanicService.ServiceHistory(); } catch (Exception ex) { Console.WriteLine(ex); }
                    break;

                case "9":
                    try { ReporteServicio.VerVentasYServiciosPorFecha(); } catch (Exception ex) { Console.WriteLine(ex); }
                    break;

                case "0":
                    Console.WriteLine("Saliendo del sistema...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            if (opcionGeneral != "0")
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcionGeneral != "0");
    }
}
