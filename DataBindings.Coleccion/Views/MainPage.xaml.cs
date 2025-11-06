using DataBindings.Coleccion.Models;

namespace DataBindings.Coleccion.Views;

public partial class MainPage : ContentPage
{
	private List<OrigenDelPaquete> _origenes;

	public MainPage()
	{
		InitializeComponent();
		_origenes = new List<OrigenDelPaquete>();
		CargarDatos();
		OrigenesListView.ItemsSource = _origenes;	
	}

	private void CargarDatos()
	{
		_origenes.Add(new OrigenDelPaquete
		{
			Nombre = "nuget.org",
			Origen = "https://api.nuget,org/v3/index.json",
			EstaHabilitado = true,
		});

        _origenes.Add(new OrigenDelPaquete
        {
            Nombre = "Microsoft Visual Studio Offline Packages",
            Origen = "C:\\Program File (x86)\\Microsoft SDKs\\NugetPackages\\",
            EstaHabilitado = true,
        });
    }

	private void ActualizaCampoDeEntrada()
	{
		var origen = OrigenesListView.SelectedItem as OrigenDelPaquete;

		if (origen != null)
		{
			NombreEntry.Text = origen.Nombre;
			OrigenEntry.Text = origen.Origen;
		}
		else
		{
            NombreEntry.Text = string.Empty;
            OrigenEntry.Text = string.Empty;
        }
	}

	private void OnAddButtonCliked(object sender, EventArgs e)
	{
		var origen = new OrigenDelPaquete
		{
			Nombre = "Nombre del origen del paquete",
			Origen = "URL o ruta del orgine del paquete",
			EstaHabilitado = false,
		};

        _origenes.Add(origen);
		OrigenesListView.ItemsSource = null;
		OrigenesListView.ItemsSource = _origenes;
		OrigenesListView.SelectedItem = origen;
		ActualizaCampoDeEntrada();
    }	
	
	private void OnRemoveButtonCliked(object sender, EventArgs e)
	{
		OrigenDelPaquete seleccionado = 
			(OrigenDelPaquete) OrigenesListView.SelectedItem;

		if (seleccionado != null)
		{
            var indice = _origenes.IndexOf(seleccionado);
			OrigenDelPaquete? nuevoseleccionado;
			if(indice < _origenes.Count - 1)
			{
				nuevoseleccionado = _origenes[indice + 1];
			}
			else
			{
				if (_origenes.Count > 1)
				{
                   nuevoseleccionado = _origenes[_origenes.Count - 2];
                }
				else
				{
					nuevoseleccionado = null;
				}
			}
		

		    _origenes.Remove(seleccionado);
			OrigenesListView.ItemsSource = null;
            OrigenesListView.ItemsSource = _origenes;
			OrigenesListView.SelectedItem = nuevoseleccionado;
			//ActualizaCampoDeEntrada();
        }				
    }

    private void OnSelectedOrigenesListView(object sender, SelectionChangedEventArgs e)
    {
        ActualizaCampoDeEntrada();

    }

    private void OnActualizarButton_Clicked(object sender, EventArgs e)
    {
		OrigenDelPaquete? seleccionado = OrigenesListView.SelectedItem as OrigenDelPaquete;

		if (seleccionado != null)
		{
			seleccionado.Nombre = NombreEntry.Text;
			seleccionado.Origen = OrigenEntry.Text;
			OrigenesListView.ItemsSource = null;
			OrigenesListView.ItemsSource = _origenes;	
		}
    }

}