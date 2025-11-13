using DataBindings.Coleccion.Models;
using System.Collections.ObjectModel;

namespace DataBindings.Coleccion.Views;

public partial class MainPage : ContentPage
{
	private OrigenDelPaquete? _origenSeleccionado;
	private string _nombreDelOrigen = string.Empty;
	private string _rutaDelOrigen = string.Empty;
	public ObservableCollection<OrigenDelPaquete> Origenes {get;}
	
	public OrigenDelPaquete? OrigenSeleccionado
	{
		get => _origenSeleccionado;
		set
		{
			if (_origenSeleccionado != value)
			{
				_origenSeleccionado = value;
				OnPropertyChanged(nameof(OrigenSeleccionado));
			}
		}
	}

	public string NombreDelOrigen
	{
		get => _nombreDelOrigen;
		set {
			if (_nombreDelOrigen != value) {
				_nombreDelOrigen = value;
				OnPropertyChanged(nameof(NombreDelOrigen));
			}
		}
	}

	public string RutaDelOrigen
	{
		get => _rutaDelOrigen;
		set
		{
			if (_rutaDelOrigen != value)
			{
				_rutaDelOrigen = value;
				OnPropertyChanged(nameof(RutaDelOrigen));
			}
		}
	}

	public MainPage()
	{
		InitializeComponent();
		Origenes = new ObservableCollection<OrigenDelPaquete>();
		CargarDatos();
		BindingContext = this;

		if (Origenes.Count > 0) {
            OrigenSeleccionado = Origenes[0];
		}
		else
		{
			OrigenSeleccionado = null;
		}
		
	}

	private void CargarDatos()
	{
		Origenes.Add(new OrigenDelPaquete
		{
			Nombre = "nuget.org",
			Origen = "https://api.nuget,org/v3/index.json",
			EstaHabilitado = true,
		});

        Origenes.Add(new OrigenDelPaquete
        {
            Nombre = "Microsoft Visual Studio Offline Packages",
            Origen = "C:\\Program File (x86)\\Microsoft SDKs\\NugetPackages\\",
            EstaHabilitado = true,
        });
    }

	private void OnAddButtonCliked(object sender, EventArgs e)
	{
		var origen = new OrigenDelPaquete
		{
			Nombre = "Nombre del origen del paquete",
			Origen = "URL o ruta del orgine del paquete",
			EstaHabilitado = false,
		};

        Origenes.Add(origen);
		OrigenSeleccionado = origen;
    }	
	
	private void OnRemoveButtonCliked(object sender, EventArgs e)
	{
				
		if (OrigenSeleccionado != null)
		{
            var indice = Origenes.IndexOf(OrigenSeleccionado);
			OrigenDelPaquete? nuevoseleccionado;

			if(indice < Origenes.Count - 1)
			{
				nuevoseleccionado = Origenes[indice + 1];
			}
			else
			{
				if (Origenes.Count > 1)
				{
                    nuevoseleccionado = Origenes[Origenes.Count - 2];
                }
				else
				{
					nuevoseleccionado = null;
				}
			}
		
			Origenes.Remove(OrigenSeleccionado);
			OrigenSeleccionado = nuevoseleccionado;
        }				
    }

    private void OrigenesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		if (OrigenSeleccionado != null)
		{
            NombreDelOrigen = OrigenSeleccionado.Nombre;
            RutaDelOrigen = OrigenSeleccionado.Origen;
        }
		else
		{
			NombreDelOrigen = string.Empty;
			RutaDelOrigen = string.Empty;
		}
	}

    private void OnActualizarButton_Clicked(object sender, EventArgs e)
    {

		if (OrigenSeleccionado != null)
		{
			if(!OrigenSeleccionado.Nombre.Equals(NombreDelOrigen)
				|| !OrigenSeleccionado.Origen.Equals(RutaDelOrigen))
			{
				OrigenSeleccionado.Nombre = NombreDelOrigen;
				OrigenSeleccionado.Origen = RutaDelOrigen;
            }            
		}
    }

}