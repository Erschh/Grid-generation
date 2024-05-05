using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class DataGrid
 {
    public bool[,] Layout{get;set;}

    public DataGrid(int x, int y)
    {
        Layout=new bool[x,y];

        for(int i=0;i<x;i++)
        {
            for(int j=0;j<y;j++)
            {
                Layout[i,j]=false;
            }
        }
    }

    public void GenerateContinous()
    {
        int x=this.Layout.GetLength(0)-1;
        int y=this.Layout.GetLength(1)-1;

        int middlex=Layout.GetLength(0)/2;
        int middley=Layout.GetLength(1)/2;
        Layout[middlex,middley]=true;
        int toleft=middley;
        int toright=middley;
        int todown=middlex;
        int toup=middlex;

        Random random=new Random();


        while((toleft>2||todown<x-2||toup>2||toright<y-2))
        {
            if (toleft>2)
            {
                for(int i=toup; i<=todown; i++)
                {
                    if(Layout[i,toleft]) GenerateNew(i, toleft);
                }
                toleft--;
            }

            if (toright<y-2)
            {
                for(int i=todown; i>=toup; i--)
                {
                    if(Layout[i,toright]) GenerateNew(i,toright);
                }
                toright++;
            }

            if (toup>2)
            {
                for(int i=toright; i>=toleft; i--)
                {
                    if(Layout[toup,i]) GenerateNew(toup,i);
                }
                toup--;
            }

            if (todown<x-2)
            {
                for(int i=toleft; i<=toright; i++)
                {
                    if(Layout[todown,i]) GenerateNew(todown, i);
                }
                todown++;
            }
            
        }
    }


    public void GenerateContinous(int density)
    {
        int x=this.Layout.GetLength(0)-1;
        int y=this.Layout.GetLength(1)-1;

        int middlex=Layout.GetLength(0)/2;
        int middley=Layout.GetLength(1)/2;
        Layout[middlex,middley]=true;
        int toleft=middley;
        int toright=middley;
        int todown=middlex;
        int toup=middlex;

        Random random=new Random();


        while((toleft>2||todown<x-2||toup>2||toright<y-2))
        {
            if (toleft>2)
            {
                for(int i=toup; i<=todown; i++)
                {
                    if(Layout[i,toleft]) GenerateNew(i, toleft, density);
                }
                toleft--;
            }

            if (toright<y-2)
            {
                for(int i=todown; i>=toup; i--)
                {
                    if(Layout[i,toright]) GenerateNew(i,toright, density);
                }
                toright++;
            }

            if (toup>2)
            {
                for(int i=toright; i>=toleft; i--)
                {
                    if(Layout[toup,i]) GenerateNew(toup,i, density);
                }
                toup--;
            }

            if (todown<x-2)
            {
                for(int i=toleft; i<=toright; i++)
                {
                    if(Layout[todown,i]) GenerateNew(todown, i, density);
                }
                todown++;
            }
            
        }
    }

    public void GenerateNew(int i, int j)
    {
        Random random=new();
        if(!Layout[i+1,j]) Layout[i+1,j]=random.Next(6)>1;
        if(!Layout[i,j+1]) Layout[i,j+1]=random.Next(6)>1;
        if(!Layout[i,j-1]) Layout[i,j-1]=random.Next(6)>1;
        if(!Layout[i-1,j]) Layout[i-1,j]=random.Next(6)>1;
    }

    public void GenerateNew(int i, int j, int density)
    {
        Random random=new();
        if(!Layout[i+1,j]) Layout[i+1,j]=random.Next(density)>1;
        if(!Layout[i,j+1]) Layout[i,j+1]=random.Next(density)>1;
        if(!Layout[i,j-1]) Layout[i,j-1]=random.Next(density)>1;
        if(!Layout[i-1,j]) Layout[i-1,j]=random.Next(density)>1;
    }

    public override string ToString()
    {
        string returnString=String.Empty;
        for(int i=0; i<Layout.GetLength(0);i++)
        {
            for(int j=0; j<Layout.GetLength(1);j++)
            {
                if(Layout[i,j])
                {
                    returnString+="0";
                }
                else
                {
                    returnString+="1";
                }
            }
            returnString+="\n";
        }

        return returnString;
    }

    public bool testGrid()
    {
        for(int i=0;i<Layout.GetLength(0);i++)
        {
            for(int j=0;j<Layout.GetLength(1);j++)
            {
                if(Layout[i,j])
                {
                    if(getValidNeigbours(i,j)<1){
                        Console.WriteLine(i+" "+j);
                        return false;
                    }
                }
            }
        }
        return true;
    }

    private int getValidNeigbours(int i, int j)
    {
        int validNeigbours=0;
        if(Layout[i+1,j]) validNeigbours++;
        if(Layout[i,j+1]) validNeigbours++;
        if(Layout[i,j-1]) validNeigbours++;
        if(Layout[i-1,j]) validNeigbours++;
        return validNeigbours;
    }
 }