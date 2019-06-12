﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Models
{
    class Bitmonlandia
    {
        private Random random = new Random();

        private int seed; //atricuto que dicta la configuracion inicial del mapa y de los bitmons
        private Mapa mapa; //atributo que guarda el mapa actual de la simulacion del mundo bitmon
        private List<Bitmon> lista_bitmons_totales = new List<Bitmon>(); //lista con todos los bitmons presentes en el mapa (vivos y muertos)
        private int tiempo_Transcurrido = 0;
        private int hijos_ents = 0;

        public Bitmonlandia(int seed)
        {
            this.seed = seed;
            mapa = new Mapa(seed);


            //Se generan los bitmons predeterminados dependiendo de la seed

            if (seed == 1)
            {
                int[] tupla = { 0, 0 };
                int[] tupla2 = { 0, 4 };
                int[] tupla3 = { 4, 4 };
                int[] tupla4 = { 4, 3 };
                int[] tupla5 = { 4, 0 };
                int[] tupla6 = { 0, 1 };
                int[] tupla7 = { 1, 2 };
                int[] tupla8 = { 2, 2 };
                int[] tupla9 = { 3, 2 };
                int[] tupla10 = { 2, 3 };
                añadir_bitmon(new Taplan("Taplan", 10, 50, 100, tupla));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla2));
                añadir_bitmon(new Wetar("Wetar", 10, 80, 100, tupla3));
                añadir_bitmon(new Wetar("Wetar", 10, 80, 100, tupla4));
                añadir_bitmon(new Gofue("Gofue", 10, 80, 100, tupla5));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 80, 100, tupla6));
                añadir_bitmon(new Taplan("Taplan", 10, 80, 100, tupla7));
                añadir_bitmon(new Gofue("Gofue", 10, 80, 100, tupla8));
                añadir_bitmon(new Taplan("Taplan", 10, 80, 100, tupla9));
                añadir_bitmon(new Doti("Doti", 10, 80, 100, tupla10));
                PosicionInicialBitmons();
            }

            if (seed == 2)
            {
                int[] tupla = { 9, 2 };
                int[] tupla2 = { 9, 3 };
                int[] tupla3 = { 8, 3 };
                int[] tupla4 = { 1, 6 };
                int[] tupla5 = { 1, 7 };
                int[] tupla6 = { 0, 6 };
                int[] tupla7 = { 6, 0 };
                int[] tupla8 = { 7, 0 };
                int[] tupla9 = { 2, 3 };
                int[] tupla10 = { 9, 8 };
                int[] tupla11 = { 9, 9 };
                int[] tupla12 = { 8, 9 };
                int[] tupla13 = { 9, 5 };
                int[] tupla14 = { 8, 1 };
                int[] tupla15 = { 1, 1 };
                int[] tupla16 = { 1, 2 };
                int[] tupla17 = { 2, 1 };
                int[] tupla18 = { 2, 2 };
                añadir_bitmon(new Taplan("Taplan", 10, 50, 100, tupla));
                añadir_bitmon(new Taplan("Taplan", 10, 50, 100, tupla2));
                añadir_bitmon(new Taplan("Taplan", 10, 50, 100, tupla3));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla4));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla5));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla6));
                añadir_bitmon(new Wetar("Wetar", 10, 80, 100, tupla7));
                añadir_bitmon(new Wetar("Wetar", 10, 80, 100, tupla8));
                añadir_bitmon(new Wetar("Wetar", 10, 80, 100, tupla9));
                añadir_bitmon(new Gofue("Gofue", 10, 80, 100, tupla10));
                añadir_bitmon(new Gofue("Gofue", 10, 80, 100, tupla11));
                añadir_bitmon(new Gofue("Gofue", 10, 80, 100, tupla12));
                añadir_bitmon(new Ent("Ent", 10, 80, 100, tupla13));
                añadir_bitmon(new Ent("Ent", 10, 80, 100, tupla14));
                añadir_bitmon(new Gofue("Gofue", 10, 80, 100, tupla15));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 80, 100, tupla16));
                añadir_bitmon(new Doti("Doti", 10, 80, 100, tupla17));
                añadir_bitmon(new Doti("Doti", 10, 80, 100, tupla18));
                PosicionInicialBitmons();
            }

            if (seed == 3)
            {
                int[] tupla = { 5, 7 };
                int[] tupla2 = { 6, 7 };
                int[] tupla3 = { 7, 7 };
                int[] tupla4 = { 6, 14 };
                int[] tupla5 = { 7, 14 };
                int[] tupla6 = { 8, 14 };
                int[] tupla7 = { 6, 0 };
                int[] tupla8 = { 6, 1 };
                int[] tupla9 = { 7, 0 };
                int[] tupla10 = { 11, 0 };
                int[] tupla11 = { 11, 1 };
                int[] tupla12 = { 12, 2 };
                int[] tupla13 = { 1, 2 };
                int[] tupla14 = { 2, 2 };
                int[] tupla15 = { 12, 7 };
                int[] tupla16 = { 1, 7 };
                int[] tupla17 = { 7, 10 };
                int[] tupla18 = { 8, 10 };
                int[] tupla19 = { 8, 7 };
                int[] tupla20 = { 1, 12 };
                int[] tupla21 = { 2, 12 };
                int[] tupla22 = { 3, 11 };
                int[] tupla23 = { 12, 0 };
                int[] tupla24 = { 11, 1 };
                int[] tupla25 = { 12, 2 };
                int[] tupla26 = { 5, 6 };
                int[] tupla27 = { 6, 6 };
                int[] tupla28 = { 7, 6 };
                int[] tupla29 = { 8, 6 };
                int[] tupla30 = { 9, 14 };
                int[] tupla31 = { 10, 14 };
                int[] tupla32 = { 11, 14 };
                int[] tupla33 = { 6, 13 };
                int[] tupla34 = { 7, 13 };
                int[] tupla35 = { 8, 13 };
                añadir_bitmon(new Taplan("Taplan", 10, 50, 100, tupla));
                añadir_bitmon(new Taplan("Taplan", 10, 50, 100, tupla2));
                añadir_bitmon(new Taplan("Taplan", 10, 50, 100, tupla3));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla4));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla5));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla6));
                añadir_bitmon(new Wetar("Wetar", 10, 80, 100, tupla7));
                añadir_bitmon(new Wetar("Wetar", 10, 80, 100, tupla8));
                añadir_bitmon(new Wetar("Wetar", 10, 80, 100, tupla9));
                añadir_bitmon(new Gofue("Gofue", 10, 80, 100, tupla10));
                añadir_bitmon(new Gofue("Gofue", 10, 80, 100, tupla11));
                añadir_bitmon(new Gofue("Gofue", 10, 80, 100, tupla12));
                añadir_bitmon(new Ent("Ent", 10, 80, 100, tupla13));
                añadir_bitmon(new Ent("Ent", 10, 80, 100, tupla14));
                añadir_bitmon(new Doti("Doti", 10, 80, 100, tupla15));
                añadir_bitmon(new Doti("Doti", 10, 80, 100, tupla16));
                añadir_bitmon(new Doti("Doti", 10, 80, 100, tupla17));
                añadir_bitmon(new Doti("Doti", 10, 80, 100, tupla18));
                añadir_bitmon(new Taplan("Taplan", 10, 50, 100, tupla19));
                añadir_bitmon(new Wetar("Wetar", 10, 80, 100, tupla20));
                añadir_bitmon(new Wetar("Wetar", 10, 80, 100, tupla21));
                añadir_bitmon(new Wetar("Wetar", 10, 80, 100, tupla22));
                añadir_bitmon(new Gofue("Gofue", 10, 80, 100, tupla23));
                añadir_bitmon(new Gofue("Gofue", 10, 80, 100, tupla24));
                añadir_bitmon(new Gofue("Gofue", 10, 80, 100, tupla25));
                añadir_bitmon(new Taplan("Taplan", 10, 50, 100, tupla26));
                añadir_bitmon(new Taplan("Taplan", 10, 50, 100, tupla27));
                añadir_bitmon(new Taplan("Taplan", 10, 50, 100, tupla28));
                añadir_bitmon(new Taplan("Taplan", 10, 50, 100, tupla29));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla30));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla31));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla32));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla33));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla34));
                añadir_bitmon(new Dorvalo("Dorvalo", 10, 60, 100, tupla35));
                PosicionInicialBitmons();
            }
        }

        //Metodos:
        //Esta funcion retorna el tiempo transcurrido en meses que esta en private en esta clase
        public int GetTiempoTranscurrido()
        {
            return tiempo_Transcurrido;
        }

        //Agregar en un mes cada vez que esta funcion es llamada
        public void SetTiempoTranscurrido()
        {
            tiempo_Transcurrido += 1;
        }


        public List<Bitmon> GetLista()
        {
            return lista_bitmons_totales;
        }


        public void añadir_bitmon(Bitmon bitmon)
        {
            lista_bitmons_totales.Add(bitmon);
            string sigla = bitmon.GetNombre().Substring(0, 3);
            int x = bitmon.GetPosicion()[0];
            int y = bitmon.GetPosicion()[1];
            if (GetMapa().GetTablero()[x, y, 1] == "   ")
            {
                mapa.SetBitmon(sigla, x, y, 1);
            }

            else if (GetMapa().GetTablero()[x, y, 2] == "   ")
            {
                mapa.SetBitmon(sigla, x, y, 2);
            }
        }

        //Funcion que posiciona los bitmons INICIALES
        public void PosicionInicialBitmons()
        {
            for (int bit = 0; bit < lista_bitmons_totales.Count(); bit++)
            {
                string sigla = lista_bitmons_totales[bit].GetNombre().Substring(0, 3);
                int x = lista_bitmons_totales[bit].GetPosicion()[0];
                int y = lista_bitmons_totales[bit].GetPosicion()[1];
                mapa.SetBitmon(sigla, x, y, 1);
            }
        }

        //Funcion que imprime el tablero en pantalla y da acceso a el map que es privado
        public Mapa GetMapa()
        {
            mapa.GetTablero();
            return mapa;
        }

        public void GetInformacion()
        {
            for (int i = 0; i < lista_bitmons_totales.Count(); i++)
            {
                Console.WriteLine("{0} : posicion:[{1},{2}], hp: {3}, estado:{4}", lista_bitmons_totales[i].GetNombre(), lista_bitmons_totales[i].GetPosicion()[0], lista_bitmons_totales[i].GetPosicion()[1], lista_bitmons_totales[i].GetPuntosDeVida(), lista_bitmons_totales[i].GetEstadoDeVida());

            }
        }

        //Spawnear Ent
        public void PlantarEnt(int size)
        {
            int c1 = random.Next(size*5); // Asignacion de una coordenada aleatoria
            int c2 = random.Next(size*5); // Asignacion de una coordenada aleatoria

            //Veo si el bitmon caera fuera de los limites del mapa:
            int cont_de_escape = 0;
            while (GetMapa().GetTablero()[c1, c2, 1] != "   " && GetMapa().GetTablero()[c1, c2, 2] != "   ")
            {
                if (cont_de_escape > 20)
                    return;
                c1 = random.Next(size*5); // Asignacion de una coordenada aleatoria
                c2 = random.Next(size*5); // Asignacion de una coordenada aleatoria
                cont_de_escape++;
            }

            int[] tupla = { c1, c2 };

            //Estadisticas
            int pa = random.Next(10, 50);
            int pv = random.Next(10, 100);
            añadir_bitmon(new Ent("Ent", 15, pa, pv, tupla));
            hijos_ents += 1;
            Console.WriteLine("Ha nacido un Ent");

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Resumen del Simulacion
        //Tiempo de vida promedio Bitmon:
        public string TiempoDeVidaPromedioBitmon()
        {
            float suma = 0;
            float cantidad_muertos = 0;
            for (int bit = 0; bit < GetLista().Count(); bit++)
            {
                if (GetLista()[bit].GetEstadoDeVida() == false)
                {
                    suma += (float)GetLista()[bit].GetMesesVividos();
                    cantidad_muertos += 1;
                }
            }

            if (cantidad_muertos > 0)
            {
                float resultado = (float)(suma / cantidad_muertos);
                string text = String.Format("Tiempo de vida promedio Bitmon: {0} meses\r\n", resultado);
                File.AppendAllText("resumen.txt", text);
                text = String.Format("{0} meses\r\n", resultado);
                return text;
            }

            else
            {
                string text = "Ningun Bitmon murio\r\n";
                File.AppendAllText("resumen.txt", text);
                return text;
            }
        }

        //Tiempo de vida promedio de cada especie:
        public string TiempoDeVidaPromedioEspecie(string especie)
        {
            float suma = 0;
            float cantidad_muertos = 0;
            for (int bit = 0; bit < GetLista().Count(); bit++)
            {
                if (GetLista()[bit].GetEstadoDeVida() == false && GetLista()[bit].GetNombre() == especie)
                {
                    suma += (float)GetLista()[bit].GetMesesVividos();
                    cantidad_muertos += 1;
                }
            }

            if (cantidad_muertos > 0)
            {
                float resultado = (float)(suma / cantidad_muertos);
                string text = String.Format("Tiempo de vida promedio {0}: {1} meses\r\n", especie, resultado);
                File.AppendAllText("resumen.txt", text);
                text= String.Format("{0} meses\r\n", resultado);
                return text;
            }

            else
            {
                string text = String.Format("No murio ningun {0}\r\n", especie, especie);
                File.AppendAllText("resumen.txt", text);
                return text;
            }
        }

        //Tasas de natalidad de cada especie:
        public string TasaDeNatalidad(string especie)
        {
            float n_nacimientos = 0;
            float poblacion_total = 0;
            if (especie != "Ent")
            {
                for (int bit = 0; bit < GetLista().Count(); bit++)
                {
                    if (GetLista()[bit].GetEstadoDeVida() == true && GetLista()[bit].GetNombre() == especie)
                    {
                        poblacion_total += (float)GetLista()[bit].GetMesesVividos();
                        n_nacimientos += (float)GetLista()[bit].GetHijos();
                    }
                }
            }

            else
            {
                for (int bit = 0; bit < GetLista().Count(); bit++)
                {
                    if (GetLista()[bit].GetEstadoDeVida() == true && GetLista()[bit].GetNombre() == especie)
                    {
                        poblacion_total += (float)GetLista()[bit].GetMesesVividos();
                    }
                }
                n_nacimientos = hijos_ents;
            }


            if (n_nacimientos > 0 && poblacion_total > 0)
            {
                float resultado = ((float)(n_nacimientos / poblacion_total)) * 1000;
                string text = String.Format("Tasa bruta de natalidad {0}: {1}\r\n", especie, resultado);
                File.AppendAllText("resumen.txt", text);
                text = String.Format("{0}\r\n", resultado);
                return text;
            }

            else
            {
                string text = String.Format("No nacio ningun {0}\r\n", especie);
                File.AppendAllText("resumen.txt", text);
                return text;
            }

        }

        //Tasas de mortalidad de cada especie:
        public string TasaDeMortalidad(string especie)
        {
            float n_muertos = 0;
            float poblacion_total = GetLista().Count();
            for (int bit = 0; bit < GetLista().Count(); bit++)
            {
                if (GetLista()[bit].GetEstadoDeVida() == false && GetLista()[bit].GetNombre() == especie)
                {
                    n_muertos += 1;
                }
            }

            if (n_muertos > 0 && poblacion_total > 0)
            {
                float resultado = ((float)(n_muertos / poblacion_total)) * 100;
                string text = String.Format("Tasa bruta de mortalidad {0}: {1}\r\n", especie, resultado);
                File.AppendAllText("resumen.txt", text);
                text = String.Format("{0}\r\n", resultado);
                return text;
            }

            else
            {
                string text = String.Format("No murio ningun {0}\r\n", especie);
                File.AppendAllText("resumen.txt", text);
                return text;
            }
        }

        //Promedio de hijos por especie:
        public string HijosPromedioEspecie(string especie)
        {
            float n_nacimientos = 0;
            float poblacion_total = 0;
            for (int bit = 0; bit < GetLista().Count(); bit++)
            {
                if (GetLista()[bit].GetNombre() == especie)
                {
                    poblacion_total += (float)GetLista()[bit].GetMesesVividos();
                    n_nacimientos += (float)GetLista()[bit].GetHijos();
                }
            }

            if (n_nacimientos > 0 && poblacion_total > 0)
            {
                float resultado = ((float)(n_nacimientos / poblacion_total)) * 1000;
                string text = String.Format("Cantidad de hijos promedio {0}: {1}\r\n", especie, resultado);
                File.AppendAllText("resumen.txt", text);
                text = String.Format("{0}\r\n", resultado);
                return text;
            }

            else
            {
                string text = String.Format("Ningun {0} ha tenido hijos\r\n", especie);
                File.AppendAllText("resumen.txt", text);
                return text;
            }


        }

        //Listado especies extintas:
        public List<string> GetEspeciesExtintas()
        {
            List<string> lista = new List<string>();

            int n_tap = 0;
            int n_dor = 0;
            int n_dot = 0;
            int n_ent = 0;
            int n_gof = 0;
            int n_wet = 0;

            for (int bit = 0; bit < GetLista().Count(); bit++)
            {
                if (GetLista()[bit].GetEstadoDeVida() == true)
                {
                    switch (GetLista()[bit].GetNombre())
                    {
                        case "Taplan":
                            n_tap += 1;
                            break;

                        case "Dorvalo":
                            n_dor += 1;
                            break;

                        case "Doti":
                            n_dot += 1;
                            break;

                        case "Ent":
                            n_ent += 1;
                            break;

                        case "Gofue":
                            n_gof += 1;
                            break;

                        case "Wetar":
                            n_wet += 1;
                            break;
                    }
                }
            }

            if (n_tap != 0 && n_dor != 0 && n_dot != 0 && n_ent != 0 && n_wet != 0 && n_gof != 0)
            {
                lista.Add("No hay especies extintas");
                File.AppendAllText("resumen.txt", "No hay especies extintas\r\n");
                return lista;
            }

            else
            {
                if (n_tap == 0)
                {
                    lista.Add("Taplan");
                    File.AppendAllText("resumen.txt", "Taplan\r\n");
                }

                if (n_dor == 0)
                {
                    lista.Add("Dorvalo");
                    File.AppendAllText("resumen.txt", "Dorvalo\r\n");
                }

                if (n_dot == 0)
                {
                    lista.Add("Doti");
                    File.AppendAllText("resumen.txt", "Doti\r\n");
                }

                if (n_ent == 0)
                {
                    lista.Add("Ent");
                    File.AppendAllText("resumen.txt", "Ent\r\n");
                }

                if (n_gof == 0)
                {
                    lista.Add("Gofue");
                    File.AppendAllText("resumen.txt", "Gofue\r\n");
                }

                if (n_wet == 0)
                {
                    lista.Add("Wetar");
                    File.AppendAllText("resumen.txt", "Wetar\r\n");
                }
                return lista;
            }
        }

        //Bithalla:
        public List<string> Bithalla()
        {
            List<string> lista = new List<string>();

            int n_tap = 0;
            int n_dor = 0;
            int n_dot = 0;
            int n_ent = 0;
            int n_gof = 0;
            int n_wet = 0;
            float muertos_total = 0;

            for (int bit = 0; bit < GetLista().Count(); bit++)
            {
                if (GetLista()[bit].GetEstadoDeVida() == false)
                {
                    switch (GetLista()[bit].GetNombre())
                    {
                        case "Taplan":
                            n_tap += 1;
                            break;

                        case "Dorvalo":
                            n_dor += 1;
                            break;

                        case "Doti":
                            n_dot += 1;
                            break;

                        case "Ent":
                            n_ent += 1;
                            break;

                        case "Gofue":
                            n_gof += 1;
                            break;

                        case "Wetar":
                            n_wet += 1;
                            break;
                    }
                    muertos_total += 1;
                }
            }

            if (n_tap == 0 && n_dor == 0 && n_dot == 0 && n_ent == 0 && n_wet == 0 && n_gof == 0)
            {
                lista.Add("Bithalla no tiene habitantes");
                File.AppendAllText("resumen.txt", "Bithalla no tiene habitantes\r\n");
                return lista;
            }

            else
            {
                if (n_tap != 0)
                {
                    float porcentaje = (((float)n_tap) / muertos_total) * 100;
                    string text = String.Format("Cantidad de Taplan en el Bithalla: {0}, que son el {1}% del Bithalla\r\n", n_tap, porcentaje);
                    lista.Add(text);
                    File.AppendAllText("resumen.txt", text);
                }

                else
                {
                    string text = String.Format("No hay Taplan en el Bithalla\r\n");
                    lista.Add(text);
                    File.AppendAllText("resumen.txt", text);
                }

                if (n_dor != 0)
                {
                    float porcentaje = (((float)n_dor) / muertos_total) * 100;
                    string text = String.Format("Cantidad de Dorvalo en el Bithalla: {0}, que son el {1}% del Bithalla\r\n", n_dor, porcentaje);
                    lista.Add(text);
                    File.AppendAllText("resumen.txt", text);
                }

                else
                {
                    string text = String.Format("No hay Dorvalo en el Bithalla\r\n");
                    lista.Add(text);
                    File.AppendAllText("resumen.txt", text);
                }

                if (n_dot != 0)
                {
                    float porcentaje = (((float)n_dot) / muertos_total) * 100;
                    string text = String.Format("Cantidad de Doti en el Bithalla: {0}, que son el {1}% del Bithalla\r\n", n_dot, porcentaje);
                    lista.Add(text);
                    File.AppendAllText("resumen.txt", text);
                }

                else
                {
                    string text = String.Format("No hay Doti en el Bithalla\r\n");
                    lista.Add(text);
                    File.AppendAllText("resumen.txt", text);
                }

                if (n_ent != 0)
                {
                    float porcentaje = (((float)n_ent) / muertos_total) * 100;
                    string text = String.Format("Cantidad de Ent en el Bithalla: {0}, que son el {1}% del Bithalla\r\n", n_ent, porcentaje);
                    lista.Add(text);
                    File.AppendAllText("resumen.txt", text);
                }

                else
                {
                    string text = String.Format("No hay Ent en el Bithalla\r\n");
                    lista.Add(text);
                    File.AppendAllText("resumen.txt", text);
                }

                if (n_gof != 0)
                {
                    float porcentaje = (((float)n_gof) / muertos_total) * 100;
                    string text = String.Format("Cantidad de Gofue en el Bithalla: {0}, que son el {1}% del Bithalla\r\n", n_gof, porcentaje);
                    lista.Add(text);
                    File.AppendAllText("resumen.txt", text);
                }

                else
                {
                    string text = String.Format("No hay Gofue en el Bithalla\r\n");
                    lista.Add(text);
                    File.AppendAllText("resumen.txt", text);
                }

                if (n_wet != 0)
                {
                    float porcentaje = (((float)n_wet) / muertos_total) * 100;
                    string text = String.Format("Cantidad de Wetar en el Bithalla: {0}, que son el {1}% del Bithalla\r\n", n_wet, porcentaje);
                    lista.Add(text);
                    File.AppendAllText("resumen.txt", text);
                }

                else
                {
                    string text = String.Format("No hay Wetar en el Bithalla\r\n");
                    lista.Add(text);
                    File.AppendAllText("resumen.txt", text);
                }

                return lista;
            }
        }
    }
}
