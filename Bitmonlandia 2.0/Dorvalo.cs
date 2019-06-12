﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Dorvalo:Bitmon
    {
        //Tiempo de vida maximo segun esta especie = 20

        Random random = new Random();

        public Dorvalo(string tipo_De_Bitmon, int tiempo_De_Vida, int puntos_De_Ataque, int puntos_De_Vida, int[] posicion) : base(tipo_De_Bitmon, tiempo_De_Vida, puntos_De_Ataque, puntos_De_Vida, posicion)
        {

        }

        public override void Pelea(Bitmon peleador)
        {
            if (peleador.GetNombre() == "Wetar" || peleador.GetNombre() == "Taplan" || peleador.GetNombre() == "Ent")
            {
                string rival = peleador.GetNombre();
                int multiplicador = random.Next(10, 21);

                //Dependiendo del rival, los puntos de ataque del Bitmon cambian
                if (rival == "Wetar")
                {
                    puntos_De_Ataque += multiplicador;
                }

                else if (rival == "Ent")
                {
                    puntos_De_Ataque -= multiplicador;
                }

                else if (rival == "Taplan")
                {
                    puntos_De_Ataque += 0;
                }

                while (estado_De_Vida == true && peleador.GetEstadoDeVida() == true)
                {
                    puntos_De_Vida -= peleador.GetPuntosDeAtaque();
                    peleador.RecibirAtaque(puntos_De_Ataque);
                    CambiarEstadoDeVida();
                    peleador.CambiarEstadoDeVida();
                }
                //el bitmon que gana se recupera completamente
                SetGanador(estado_De_Vida);
                peleador.SetGanador(peleador.GetEstadoDeVida());
            }
        }

        /* Reproduccion de Bitmons consiste en que si la pareja es compatible, se instancia dentro de la lista de Bitmons 
         * un nuevo Bitmon de una especie aleatoria
        */
        public override void Reproduccion(Bitmon pareja, int size, Bitmonlandia bitmonlandia)
        {
            if (pareja.GetNombre() == "Gofue" || pareja.GetNombre() == "Dorvalo" || pareja.GetNombre() == "Doti")
            {
                tiempo_De_Vida += (tiempo_De_Vida * 3) / 10;
                pareja.SetTiempoDeVida(pareja.GetTiempoDeVida() + (pareja.GetTiempoDeVida() * 3) / 10);
                int c1 = random.Next(size); // Asignacion de una coordenada aleatoria
                int c2 = random.Next(size); // Asignacion de una coordenada aleatoria

                //Veo si el bitmon caera fuera de los limites del mapa:
                int cont_de_escape = 0;
                while (bitmonlandia.GetMapa().GetTablero()[c1, c2, 1] != "   " && bitmonlandia.GetMapa().GetTablero()[c1, c2, 2] != "   ")
                {

                    //condicion de escape
                    if (cont_de_escape > 20)
                        return;
                    c1 = random.Next(size); // Asignacion de una coordenada aleatoria
                    c2 = random.Next(size); // Asignacion de una coordenada aleatoria
                    cont_de_escape++;
                }

                int[] tupla = { c1, c2 };

                //Estadisticas
                int pa = random.Next(10, ((puntos_De_Ataque + pareja.GetPuntosDeAtaque()) / 2));
                int pv = random.Next(10, ((puntos_De_Vida + pareja.GetPuntosDeVida()) / 2));

                //Veamos la cantidad de hijos que han tenido ambos
                int hijos_padre = hijos;
                int hijos_pareja = pareja.GetHijos();
                string especie_hijo = "";

                int probabilidad = random.Next(0, 101);

                if (hijos_padre > hijos_pareja)
                {
                    if (probabilidad <= 70)
                    {
                        especie_hijo = tipo_De_Bitmon;
                    }

                    else
                    {
                        especie_hijo = pareja.GetNombre();
                    }
                }

                else if (hijos_padre < hijos_pareja)
                {
                    if (probabilidad <= 70)
                    {
                        especie_hijo = pareja.GetNombre();
                    }

                    else
                    {
                        especie_hijo = tipo_De_Bitmon;
                    }
                }

                else
                {
                    if (probabilidad <= 50)
                    {
                        especie_hijo = pareja.GetNombre();
                    }

                    else
                    {
                        especie_hijo = tipo_De_Bitmon;
                    }
                }

                switch (especie_hijo)
                {
                    case "Gofue":
                        bitmonlandia.añadir_bitmon(new Gofue("Gofue", 15, pa, pv, tupla));
                        break;

                    case "Dorvalo":
                        bitmonlandia.añadir_bitmon(new Dorvalo("Dorvalo", 20, pa, pv, tupla));
                        break;

                    case "Doti":
                        bitmonlandia.añadir_bitmon(new Doti("Doti", 30, pa, pv, tupla));
                        break;
                }
                Console.WriteLine("Ha nacido un {0}", especie_hijo);
                hijos += 1;
                pareja.SetHijos();
            }
        }


        public override void Movimiento(Mapa mapa)
        {
            string[,,] tablero = mapa.GetTablero();
            int cant_filas = tablero.GetLength(0);
            int cant_columnas = tablero.GetLength(1);
            int x = posicion[0];
            int y = posicion[1];
            int vertical = random.Next(-2, 3);
            int horizontal = random.Next(-2, 3);

            //Veo si el bitmon caera fuera de los limites del mapa:
            while ((x + vertical < 0) || (y + horizontal < 0) || (x + vertical >= cant_filas) || (y + horizontal >= cant_columnas))
            {
                vertical = random.Next(-2, 3);
                horizontal = random.Next(-2, 3);
            }
            int celda_antigua = celda;
            int celda_nueva = celda;

            //Veo si esta ocupada la celda a la cual se va a mover
            while (tablero[x + vertical, y + horizontal, celda_nueva] != "   ")
            {
                //Si ya no hay mas espacio a donde se va a mover, se quedar en el mismo lugar
                if (celda_nueva == 2 && (tablero[x + vertical, y + horizontal, celda_nueva] != "   "))
                {
                    celda_nueva = celda;
                    vertical = 0;
                    horizontal = 0;
                    break;
                }
                celda_nueva++;
            }

            mapa.RemoveBitmon(x, y, celda_antigua);
            posicion[0] += vertical;
            posicion[1] += horizontal;
            celda = celda_nueva;
            string sigla = tipo_De_Bitmon.Substring(0, 3);
            mapa.SetBitmon(sigla, posicion[0], posicion[1], celda_nueva);
            //Console.WriteLine($"Tiempo de vida Dorvalo: {tiempo_De_Vida}");
        }

        // Reduce el tiempo de vida del Bitmon dependiendo de el terreno en donde se encuentre
        public override void Envejecer(Mapa mapa)
        {
            int x = GetPosicion()[0];
            int y = GetPosicion()[1];
            string[,,] tablero = mapa.GetTablero();
            terreno = tablero[x, y, 0];

            if (terreno == "L")
            {
                tiempo_De_Vida -= 2;
            }
            else
            {
                tiempo_De_Vida -= 1;
            }
            meses_vividos += 1;
        }
    }
}
