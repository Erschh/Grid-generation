using System.Linq;
using System;
using ReactiveUI;
using Avalonia.Interactivity;

namespace Grid_generation.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to grid creation!";
    public DataGrid grid=new(10,10);
    public string state="Everything's fine";
    public string Status
    {
        get=>state;
        set=>this.RaiseAndSetIfChanged(ref state, value);
    }

    public string height="50";
    public string width="50";

    public string? density;

    public string Height
    {
        get=>height;
        set=>this.RaiseAndSetIfChanged(ref height, value);
    }
    public string Width
    {
        get=>width;
        set=>this.RaiseAndSetIfChanged(ref width, value);
    }

    public string? Density
    {
        get=>density;
        set=>this.RaiseAndSetIfChanged(ref density, value);
    }

    public void GenerateMap()
    {
        int iheight, iwidth;
        if(int.TryParse(Height, out iheight)&&int.TryParse(Width, out iwidth))
        {
            grid=new DataGrid(iheight, iwidth);
            grid.GenerateContinous();
            Status="Everything's fine";
        }
        else
        {
            Status="Something went wrong";
        }
    }

    public void GenerateMapWithDensity()
    {
        int iheight, iwidth, idensity;
        if(int.TryParse(Height, out iheight)&&int.TryParse(Width, out iwidth)&&int.TryParse(Density, out idensity))
        {
            grid=new DataGrid(iheight, iwidth);
            grid.GenerateContinous(idensity);
            Status="Everything's fine";
        }
        else
        {
            Status="Something went wrong";
        }
    }

    public bool GetNodeValue(int a, int b)
    {
        try
        {
            Status="Everything's fine";
            return grid.Layout[a, b];
        }
        catch (Exception)
        {
            Status="Something went wrong";
            return false;
        }
    }

    
#pragma warning restore CA1822 // Mark members as static
}
