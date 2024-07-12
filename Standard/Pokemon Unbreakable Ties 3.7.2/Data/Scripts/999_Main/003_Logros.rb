#Script creado por Painkiller97
NOMBRES_LOGRO=[
"Primeros pasos",
"Gente rara",
"Eda y la cafeina",
"Lenador Novato",
"Lenador Intermedio",
"Lenador Avanzado",
"Lenador Experto",
"Que si que tas perdio",
"Menudo algoritmo",
"Excelentemente sexy",
"PeepoClown",
"Arqueologo del amor",
"Mondongo",
"Derrota a Majime",
"Las voces del bosque",
"Montanero triste",
"Adopta un Mimikyu",
"Entre la espada y la pared",
"Minero novato",
"Minero intermedio",
"Minero avanzado",
"Minero enfermo",
"Porrazos in the garden",
"La pelota perdida",
"Me toman por tonto",
"Antes de tiempo",
"La flor de la juventud",
"Lagrimas de un Saiyan",
"Ni dinero ni novia xd",
"Las amadas Rosquillas",
"Rompiendo la 4ta pared",
"Pokemaniaco 1",
"Pokemaniaco 2",
"Pokemaniaco 3",
"Pokemaniaco 4",
"Inversor Humilde",
"Inversor Avanzado",
"Millonario",
"Un rayo de esperanza",
"1 vs 100",
"Hasta el final"
]

DESCRIPCIONES_LOGRO=[
"Empieza a dar tus primeros pasos en Akebia.",
"Conoce a Rodolfo, un nino con un Ditto en la cabeza.",
"Eda te ha regalado una taza de cafe por tu esfuerzo.",
"Tala 15 arboles",
"Tala 50 arboles.",
"Tala 150 arboles.",
"Tala 400 arboles.",
"Se perdio buscando pkmn y la llevaste con mama.",
"Logra completar el puzzle de la Cueva Algoritmo.",
"Sabes mucho de Pkmn, por ende eres muy sexy.",
"Aguanta la falsa historia de un payaso.",
"Encuentra las llaves 'perdidas' del arqueologo.",
"Encuentra al dios del Mondongo.",
"Consigue derrotar a Majime aunque puedas perder.",
"Parece que suena algo en el Bosque del Tiempo...",
"No le has dejado hacer su broma del onix, esta feo eso.",
"Acabas adoptando un Mimikyu, por lo que sea.",
"Consigue derrotar a Brenda a la primera.",
"Mina 5 veces.",
"Mina 20 veces.",
"Mina 50 veces.",
"Mina 100 veces.",
"Consigue vencer a tu contraparte en el Jardin.",
"Consigue devolverle la pelota a un nino.",
"La presunta estafa de la iglesia.",
"Consigue derrotar a Hakan aunque debas perder.",
"Un muchacho ha perdido sus calzones de marca Sharspeedo.",
"Un personaje rarete enamorado de cojones.",
"Una muchacha enamorada se ha enfadado y lo ha dejado sin dineros.",
"Traele a Brenda sus rosquillas favoritas para ayudar a Agapito.",
"Conoce a un tio semidesnudo que trabaja en su juego.",
"Atrapa 100 Pokemon.",
"Atrapa 250 Pokemon.",
"Atrapa 500 Pokemon.",
"Atrapa 1000 Pokemon.",
"Deposita 100.000 Pokedólares en el Banco de Ciudad Lugano.",
"Deposita 500.000 Pokedólares en el Banco de Ciudad Lugano.",
"Deposita 1.000.000 Pokedólares en el Banco de Ciudad Lugano.",
"Consigue reformar la vida de un mendigo.",
"Derrotar a Shadow supone derrotar a 100 entrenadores.",
"Consiguste derrotar al besto villano al borde de la muerte."
]

class Logro
    attr_accessor :icono
    attr_accessor :nombre
    attr_accessor :desc
    attr_accessor :iconogrande
 
    def initialize(icono, nombre, desc, iconogrande, viewport)
        self.icono = Sprite.new(viewport)
        self.icono.bitmap=RPG::Cache.picture(icono)
        self.iconogrande = Sprite.new(viewport)
        self.iconogrande.bitmap=RPG::Cache.picture(iconogrande)
        self.iconogrande.x = 163
        self.iconogrande.y = 24
        self.nombre = nombre
        self.desc = desc
     end   
    
   
    def update()
        self.icono.update
        self.iconogrande.update
    end
end
 
class Pokemon_Achievements_Scene
  def pbStartScene
    @page=0
    @viewport=Viewport.new(0,0,Graphics.width,Graphics.height)
    @viewport.z=99999
    @sprites={}
    @sprites["bg"]=IconSprite.new(0,0,@viewport)

    if $game_variables[101] == 0
    	@sprites["bg"].setBitmap("Graphics/Pictures/Logros/background")
    end

    if $game_variables[101] == 1
    	@sprites["bg"].setBitmap("Graphics/Pictures/Logros/background2")
    end

    if $game_switches[510] == true
    	@sprites["bg"].setBitmap("Graphics/Pictures/Logros/background")
    end

    if $game_variables[610] == true
    	@sprites["bg"].setBitmap("Graphics/Pictures/Logros/background2")
    end

    @sprites["animacion"]=Sprite.new(@viewport)
    @sprites["animacion"].bitmap=RPG::Cache.picture("Logros/Cuadraditos")
    @sprites["animacion"].blend_type=1
   
    @sprites["animacion"].opacity=36
    @red=Color.new(255,0,0)
    @select = 0
   
    @space_logros = 20
    @offset = 20
   
    @sprites["overlay"]=BitmapSprite.new(Graphics.width,Graphics.height,@viewport)
   
    @logros = []
    @logros[0] = Logro.new("Logros/LogroMini/LogroMini1", "nombre", "desc", "Logros/LogroGrande/Logro1", @viewport)
    @logros[1] = Logro.new("Logros/LogroMini/LogroMini2", "nombre", "desc", "Logros/LogroGrande/Logro2", @viewport)
    @logros[2] = Logro.new("Logros/LogroMini/LogroMini3", "nombre", "desc", "Logros/LogroGrande/Logro3", @viewport)
    @logros[3] = Logro.new("Logros/LogroMini/LogroMini4", "nombre", "desc", "Logros/LogroGrande/Logro4", @viewport)
    @logros[4] = Logro.new("Logros/LogroMini/LogroMini5", "nombre", "desc", "Logros/LogroGrande/Logro5", @viewport)
    @logros[5] = Logro.new("Logros/LogroMini/LogroMini6", "nombre", "desc", "Logros/LogroGrande/Logro6", @viewport)
    @logros[6] = Logro.new("Logros/LogroMini/LogroMini7", "nombre", "desc", "Logros/LogroGrande/Logro7", @viewport)
    @logros[7] = Logro.new("Logros/LogroMini/LogroMini8", "nombre", "desc", "Logros/LogroGrande/Logro8", @viewport)
    @logros[8] = Logro.new("Logros/LogroMini/LogroMini9", "nombre", "desc", "Logros/LogroGrande/Logro9", @viewport)
    @logros[9] = Logro.new("Logros/LogroMini/LogroMini10", "nombre", "desc", "Logros/LogroGrande/Logro10", @viewport)
    @logros[10] = Logro.new("Logros/LogroMini/LogroMini11", "nombre", "desc", "Logros/LogroGrande/Logro11", @viewport)
    @logros[11] = Logro.new("Logros/LogroMini/LogroMini12", "nombre", "desc", "Logros/LogroGrande/Logro12", @viewport)
    @logros[12] = Logro.new("Logros/LogroMini/LogroMini13", "nombre", "desc", "Logros/LogroGrande/Logro13", @viewport)
    @logros[13] = Logro.new("Logros/LogroMini/LogroMini14", "nombre", "desc", "Logros/LogroGrande/Logro14", @viewport)
    @logros[14] = Logro.new("Logros/LogroMini/LogroMini15", "nombre", "desc", "Logros/LogroGrande/Logro15", @viewport)
    @logros[15] = Logro.new("Logros/LogroMini/LogroMini16", "nombre", "desc", "Logros/LogroGrande/Logro16", @viewport)
    @logros[16] = Logro.new("Logros/LogroMini/LogroMini17", "nombre", "desc", "Logros/LogroGrande/Logro17", @viewport)
    @logros[17] = Logro.new("Logros/LogroMini/LogroMini18", "nombre", "desc", "Logros/LogroGrande/Logro18", @viewport)
    @logros[18] = Logro.new("Logros/LogroMini/LogroMini19", "nombre", "desc", "Logros/LogroGrande/Logro19", @viewport)
    @logros[19] = Logro.new("Logros/LogroMini/LogroMini20", "nombre", "desc", "Logros/LogroGrande/Logro20", @viewport)
    @logros[20] = Logro.new("Logros/LogroMini/LogroMini21", "nombre", "desc", "Logros/LogroGrande/Logro21", @viewport)
    @logros[21] = Logro.new("Logros/LogroMini/LogroMini22", "nombre", "desc", "Logros/LogroGrande/Logro22", @viewport)
    @logros[22] = Logro.new("Logros/LogroMini/LogroMini23", "nombre", "desc", "Logros/LogroGrande/Logro23", @viewport)
    @logros[23] = Logro.new("Logros/LogroMini/LogroMini24", "nombre", "desc", "Logros/LogroGrande/Logro24", @viewport)
    @logros[24] = Logro.new("Logros/LogroMini/LogroMini25", "nombre", "desc", "Logros/LogroGrande/Logro25", @viewport)
    @logros[25] = Logro.new("Logros/LogroMini/LogroMini26", "nombre", "desc", "Logros/LogroGrande/Logro26", @viewport)
    @logros[26] = Logro.new("Logros/LogroMini/LogroMini27", "nombre", "desc", "Logros/LogroGrande/Logro27", @viewport)
    @logros[27] = Logro.new("Logros/LogroMini/LogroMini28", "nombre", "desc", "Logros/LogroGrande/Logro28", @viewport)
    @logros[28] = Logro.new("Logros/LogroMini/LogroMini29", "nombre", "desc", "Logros/LogroGrande/Logro29", @viewport)
    @logros[29] = Logro.new("Logros/LogroMini/LogroMini30", "nombre", "desc", "Logros/LogroGrande/Logro30", @viewport)
    @logros[30] = Logro.new("Logros/LogroMini/LogroMini31", "nombre", "desc", "Logros/LogroGrande/Logro31", @viewport)
    @logros[31] = Logro.new("Logros/LogroMini/LogroMini32", "nombre", "desc", "Logros/LogroGrande/Logro32", @viewport)
    @logros[32] = Logro.new("Logros/LogroMini/LogroMini33", "nombre", "desc", "Logros/LogroGrande/Logro33", @viewport)
    @logros[33] = Logro.new("Logros/LogroMini/LogroMini34", "nombre", "desc", "Logros/LogroGrande/Logro34", @viewport)
    @logros[34] = Logro.new("Logros/LogroMini/LogroMini35", "nombre", "desc", "Logros/LogroGrande/Logro35", @viewport)
    @logros[35] = Logro.new("Logros/LogroMini/LogroMini36", "nombre", "desc", "Logros/LogroGrande/Logro36", @viewport)
    @logros[36] = Logro.new("Logros/LogroMini/LogroMini37", "nombre", "desc", "Logros/LogroGrande/Logro37", @viewport)
    @logros[37] = Logro.new("Logros/LogroMini/LogroMini38", "nombre", "desc", "Logros/LogroGrande/Logro38", @viewport)
    @logros[38] = Logro.new("Logros/LogroMini/LogroMini39", "nombre", "desc", "Logros/LogroGrande/Logro39", @viewport)
    @logros[39] = Logro.new("Logros/LogroMini/LogroMini40", "nombre", "desc", "Logros/LogroGrande/Logro40", @viewport)
    @logros[40] = Logro.new("Logros/LogroMini/LogroMini41", "nombre", "desc", "Logros/LogroGrande/Logro41", @viewport)

    @sprites["selector"] = @uparrow=AnimatedSprite.create("Graphics/Pictures/uparrow",8,2,@viewport)
    @sprites["selector"].x = (@logros[0].icono.bitmap.width)/2 + @offset - @sprites["selector"].framewidth/2
    @sprites["selector"].y = Graphics.height/2 + 25
    @sprites["selector"].play
    
    #Cosas p gina2
    
    @sprites["TitleBox"]=IconSprite.new(0,0,@viewport)
    @sprites["TitleBox"].x = 152
    @sprites["TitleBox"].y = 245
    @sprites["TitleBox"].visible=false
    @sprites["TitleBox"].setBitmap("Graphics/Pictures/Logros/LogroGrande/TitleBox")
    
    @sprites["TextBox"]=IconSprite.new(0,0,@viewport)
    @sprites["TextBox"].x = 6
    @sprites["TextBox"].y = 299
    @sprites["TextBox"].visible=false
    @sprites["TextBox"].setBitmap("Graphics/Pictures/Logros/LogroGrande/DescriptionBox")
    
    @sprites["overlay2"]=BitmapSprite.new(Graphics.width, Graphics.height, @viewport)
    @sprites["overlay2"].visible=false
    pbSetSystemFont(@sprites["overlay"].bitmap)
    pbSetSystemFont(@sprites["overlay2"].bitmap)
    @nombrelogro = NOMBRES_LOGRO
    @desclogro = DESCRIPCIONES_LOGRO
    pbText
    pbInput
  end
 
  def pbText
    overlay=@sprites["overlay"].bitmap
    pubid=sprintf("%05d",$Trainer.public_ID($Trainer.id))
    baseColor=Color.new(250,250,250)
    shadowColor=Color.new(60,60,60)
    #textPositions=[
     #  [_INTL("Prueba"),274,326,false,baseColor,shadowColor]
     # ]
    #pbDrawTextPositions(overlay,textPositions)  
  end
 
  def update
    if @page==0
     @logros[0].iconogrande.visible = false
     @logros[1].iconogrande.visible = false
     @logros[2].iconogrande.visible = false
     @logros[3].iconogrande.visible = false
     @logros[4].iconogrande.visible = false
     @logros[5].iconogrande.visible = false
     @logros[6].iconogrande.visible = false
     @logros[7].iconogrande.visible = false
     @logros[8].iconogrande.visible = false
     @logros[9].iconogrande.visible = false
     @logros[10].iconogrande.visible = false
     @logros[11].iconogrande.visible = false
     @logros[12].iconogrande.visible = false
     @logros[13].iconogrande.visible = false
     @logros[14].iconogrande.visible = false
     @logros[15].iconogrande.visible = false
     @logros[16].iconogrande.visible = false
     @logros[17].iconogrande.visible = false
     @logros[18].iconogrande.visible = false
     @logros[19].iconogrande.visible = false
     @logros[20].iconogrande.visible = false
     @logros[21].iconogrande.visible = false
     @logros[22].iconogrande.visible = false
     @logros[23].iconogrande.visible = false
     @logros[24].iconogrande.visible = false
     @logros[25].iconogrande.visible = false
     @logros[26].iconogrande.visible = false
     @logros[27].iconogrande.visible = false
     @logros[28].iconogrande.visible = false
     @logros[29].iconogrande.visible = false
     @logros[30].iconogrande.visible = false
     @logros[31].iconogrande.visible = false
     @logros[32].iconogrande.visible = false
     @logros[33].iconogrande.visible = false
     @logros[34].iconogrande.visible = false
     @logros[35].iconogrande.visible = false
     @logros[36].iconogrande.visible = false
     @logros[37].iconogrande.visible = false
     @logros[38].iconogrande.visible = false
     @logros[39].iconogrande.visible = false
     @logros[40].iconogrande.visible = false
  
    end 
      @logros[@select].iconogrande.x = 163
      @logros[@select].iconogrande.y = 24
    
      @logros[@select].update
    iconscreen = 3
    nicon = 0
    for logro in @logros
        if @select >= iconscreen
          @offset2 = (@select-iconscreen) * (90 + @space_logros)
        else
          @offset2 = 0
        end 
        logro.icono.x = (logro.icono.bitmap.width + @space_logros) * nicon + @offset - @offset2
        logro.icono.y = Graphics.height/2 - logro.icono.bitmap.height / 2
    @sprites["selector"].x = ((@logros[0].icono.bitmap.width + @space_logros) * @select )+ (@logros[0].icono.bitmap.width)/2 + @offset - @offset2 - @sprites["selector"].framewidth/2
        logro.update
        nicon += 1
      end


    #Aqu  se define si un logro est  conseguido o no, uso interruptores reservados
    #as  que c mbialos de acuerdo a tu juego

####################################################################
	
    #Zapatos

    if $game_switches[701] == true
    @logros[0].icono.opacity = 255
    else  
    @logros[0].icono.opacity = 50
    end  
    
    #Rodolfo god

    if $game_switches[702] == true
    @logros[1].icono.opacity = 255
    else  
    @logros[1].icono.opacity = 50
    end
  
    #Caf 

    if $game_switches[135] == true
    @logros[2].icono.opacity = 255
    else  
    @logros[2].icono.opacity = 50
    end  

    #Madera 

    if $game_variables[300] >= 15 
    @logros[3].icono.opacity = 255
    else  
    @logros[3].icono.opacity = 50
    end  

    #Madera 

    if $game_variables[300] >= 50
    @logros[4].icono.opacity = 255
    else  
    @logros[4].icono.opacity = 50
    end  
  
    #Madera 

  if $game_variables[300] >= 150
    @logros[5].icono.opacity = 255
    else  
    @logros[5].icono.opacity = 50
  end  

    #Madera 
  
  if $game_variables[300] >= 400
    @logros[6].icono.opacity = 255
    else  
    @logros[6].icono.opacity = 50
  end  

    #Ni a perdida
  
  if $game_switches[703] == true
    @logros[7].icono.opacity = 255
    else  
    @logros[7].icono.opacity = 50
  end  

    #Cueva Algoritmo

  if $game_switches[704] 
    @logros[8].icono.opacity = 255
    else  
    @logros[8].icono.opacity = 50
  end  

    #Nota 10
 
  if $game_switches[705] 
    @logros[9].icono.opacity = 255
    else  
    @logros[9].icono.opacity = 50
  end  


    #PeepoClown

  if $game_switches[706] 
    @logros[10].icono.opacity = 255
    else  
    @logros[10].icono.opacity = 50
  end

    #Arqueologo enamorao
  
  if $game_switches[707] 
    @logros[11].icono.opacity = 255
    else  
    @logros[11].icono.opacity = 50
  end  

    #Mondongo

  if $game_switches[708] 
    @logros[12].icono.opacity = 255
    else  
    @logros[12].icono.opacity = 50
  end  

    #Majime

  if $game_switches[709] 
    @logros[13].icono.opacity = 255
    else  
    @logros[13].icono.opacity = 50
  end  

    #Celebi
  
  if $game_switches[454]
    @logros[14].icono.opacity  = 255
    else  
    @logros[14].icono.opacity  = 50
    end  

    #Monta ero F  

  if $game_switches[711] 
    @logros[15].icono.opacity = 255
    else  
    @logros[15].icono.opacity = 50
    end

    #Mimikyu

  if $game_switches[712] 
    @logros[16].icono.opacity = 255
    else  
    @logros[16].icono.opacity = 50
    end   

    #Brenda god

  if $game_switches[713] 
    @logros[17].icono.opacity = 255
    else  
    @logros[17].icono.opacity = 50
    end 

    #Minar 5

  if $game_variables[301] >= 5 
    @logros[18].icono.opacity = 255
    else  
    @logros[18].icono.opacity = 50
    end      

    #Minar 20

  if $game_variables[301] >= 20 
    @logros[19].icono.opacity = 255
    else  
    @logros[19].icono.opacity = 50
    end        

    #Minar 50

  if $game_variables[301] >= 50 
    @logros[20].icono.opacity = 255
    else  
    @logros[20].icono.opacity = 50
    end   

    #Minar 100

  if $game_variables[301] >= 100 
    @logros[21].icono.opacity = 255
    else  
    @logros[21].icono.opacity = 50
    end 

    #Derrota Lluvia / Adri n

  if $game_switches[714] == true
    @logros[22].icono.opacity = 255
    else  
    @logros[22].icono.opacity = 50
    end 

    #Xylon pelota

  if $game_switches[715] == true
    @logros[23].icono.opacity = 255
    else  
    @logros[23].icono.opacity = 50
    end

    #iglesia

  if $game_switches[716] == true
    @logros[24].icono.opacity = 255
    else  
    @logros[24].icono.opacity = 50
    end

    #Hakan

  if $game_switches[717] == true
    @logros[25].icono.opacity = 255
    else  
    @logros[25].icono.opacity = 50
    end

    #Los calzoncillos

  if $game_switches[718] == true
    @logros[26].icono.opacity = 255
    else  
    @logros[26].icono.opacity = 50
    end

  #Vegetita

  if $game_switches[725] == true
    @logros[27].icono.opacity = 255
    else  
    @logros[27].icono.opacity = 50
    end

  #Pareja F

  if $game_switches[726] == true
    @logros[28].icono.opacity = 255
    else  
    @logros[28].icono.opacity = 50
    end

  #Brenda y Agapito

  if $game_switches[727] == true
    @logros[29].icono.opacity = 255
    else  
    @logros[29].icono.opacity = 50
    end

  #SSamurai shutuber de exito

  if $game_switches[728] == true
    @logros[30].icono.opacity = 255
    else  
    @logros[30].icono.opacity = 50
    end

  # Pokedex 100

  if $game_switches[729] == true
    @logros[31].icono.opacity = 255
    else  
    @logros[31].icono.opacity = 50
    end

  # Pokedex 250

  if $game_switches[730] == true
    @logros[32].icono.opacity = 255
    else  
    @logros[32].icono.opacity = 50
    end

  # Pokedex 500

  if $game_switches[731] == true
    @logros[33].icono.opacity = 255
    else  
    @logros[33].icono.opacity = 50
    end

  # Pokedex 1000

  if $game_switches[732] == true
    @logros[34].icono.opacity = 255
    else  
    @logros[34].icono.opacity = 50
    end

  # 100000 pokedolares

  if $game_switches[733] == true
    @logros[35].icono.opacity = 255
    else  
    @logros[35].icono.opacity = 50
    end

  # 500000 pokedolares

  if $game_switches[734] == true
    @logros[36].icono.opacity = 255
    else  
    @logros[36].icono.opacity = 50
    end

  # 1000000 pokedolares

  if $game_switches[735] == true
    @logros[37].icono.opacity = 255
    else  
    @logros[37].icono.opacity = 50
    end

  # Amal mendigo

  if $game_switches[736] == true
    @logros[38].icono.opacity = 255
    else  
    @logros[38].icono.opacity = 50
    end

  if $game_switches[737] == true
    @logros[39].icono.opacity = 255
    else  
    @logros[39].icono.opacity = 50
    end

  if $game_switches[738] == true
    @logros[40].icono.opacity = 255
    else  
    @logros[40].icono.opacity = 50
    end



####################################################################
  
  
    pbUpdateSpriteHash(@sprites)
    if @sprites["animacion"]
       @sprites["animacion"].x-=1
       @sprites["animacion"].x=0 if @sprites["animacion"].x==-64
       @sprites["animacion"].y-=1
       @sprites["animacion"].y=0 if @sprites["animacion"].y==-64
    end
    Input.update
  end  
  
  def textoLogro
    pbSetSystemFont(@sprites["overlay2"].bitmap)
    overlay=@sprites["overlay2"].bitmap
    overlay.clear 
    baseColor=Color.new(225,225,225)
    shadowColor=Color.new(120,120,120)
    drawTextEx(overlay,157,250,320,0,@nombrelogro[@select],baseColor,shadowColor)
    drawTextEx(overlay,12,305,320,0,@desclogro[@select],baseColor,shadowColor)
    # textPositions=[
    #[_INTL,(@nombrelogro[@select]),157,250,0,baseColor,shadowColor],
    #[_INTL("{1} Descripcion ",@desclogro[@select]),12,305,0,baseColor,shadowColor]
    #]
    #drawTextEx(overlay,157,250,360,0,@nombrelogro[@select],baseColor,shadowColor) 
   #pbDrawTextPositions(overlay,textPositions)
  end  
 
 def pbInput
    if @page==0
      if Input.trigger?(Input::RIGHT) && !(@select==@logros.length - 1)
          @select+=1; pbPlayCursorSE
        end    
      if Input.trigger?(Input::LEFT) && !(@select==0)
          @select-=1; pbPlayCursorSE
        end
      if Input.trigger?(Input::BACK)
	  pbPlayCloseMenuSE 
          #pbEndScene
      end
    end 
    if Input.trigger?(Input::C) 
      pbPlayCursorSE
      switchPage
      textoLogro
    end
  end  

  def pbLogros
    loop do
      Graphics.update
      #Input.update
      self.pbInput
      self.update
      if Input.trigger?(Input::B)
       pbPlayCloseMenuSE 
       break
	end
      end
    end
  end
  
  def switchPage
    if @page==1
      firstPage
    else
      secondPage
      textoLogro
    end
  end  
  
  def firstPage
    @page=0
    
    @sprites["overlay"].visible=true
    for logro in @logros
      logro.icono.visible=true
    end  
    if $game_switches[184]
    @logros[0].icono.opacity = 255
    else  
    @logros[0].icono.opacity = 100
    end  
    
    @sprites["selector"].visible=true
    @sprites["overlay"].visible=true
    @sprites["TitleBox"].visible=false
    @sprites["TextBox"].visible=false
 
    @sprites["overlay2"].visible=false
     @logros[0].iconogrande.visible = false
     @logros[1].iconogrande.visible = false
     @logros[2].iconogrande.visible = false
     @logros[3].iconogrande.visible = false
     @logros[4].iconogrande.visible = false
     @logros[5].iconogrande.visible = false
     @logros[6].iconogrande.visible = false
     @logros[7].iconogrande.visible = false
     @logros[8].iconogrande.visible = false
     @logros[9].iconogrande.visible = false
     @logros[10].iconogrande.visible = false
     @logros[11].iconogrande.visible = false
     @logros[12].iconogrande.visible = false
     @logros[13].iconogrande.visible = false
     @logros[14].iconogrande.visible = false
     @logros[15].iconogrande.visible = false
     @logros[16].iconogrande.visible = false
     @logros[17].iconogrande.visible = false
     @logros[18].iconogrande.visible = false
     @logros[19].iconogrande.visible = false
     @logros[20].iconogrande.visible = false
     @logros[21].iconogrande.visible = false
     @logros[22].iconogrande.visible = false
     @logros[23].iconogrande.visible = false
     @logros[24].iconogrande.visible = false
     @logros[25].iconogrande.visible = false
     @logros[26].iconogrande.visible = false
     @logros[27].iconogrande.visible = false
     @logros[28].iconogrande.visible = false
     @logros[29].iconogrande.visible = false
     @logros[30].iconogrande.visible = false
     @logros[31].iconogrande.visible = false
     @logros[32].iconogrande.visible = false
     @logros[33].iconogrande.visible = false
     @logros[34].iconogrande.visible = false
     @logros[35].iconogrande.visible = false
     @logros[36].iconogrande.visible = false
     @logros[37].iconogrande.visible = false
     @logros[38].iconogrande.visible = false
     @logros[39].iconogrande.visible = false
     @logros[40].iconogrande.visible = false
  end
  
  def secondPage
    @page=1
    @sprites["overlay"].visible=false
    for logro in @logros
      logro.icono.visible=false
    end
    
    @sprites["selector"].visible=false
    @sprites["overlay"].visible=false
    @sprites["TitleBox"].visible=true
    @sprites["TextBox"].visible=true
    @sprites["overlay2"].visible=true
    @logros[@select].iconogrande.visible = true


    #Aqu  se define si un logro est  conseguido o no, uso interruptores reservados
    #as  que c mbialos de acuerdo a tu juego

####################################################################

    #Zapatos

    if $game_switches[701] == true
    @logros[0].iconogrande.opacity = 255
    else  
    @logros[0].iconogrande.opacity = 50
    end  

    #Rodolfo god
  
  if $game_switches[702] == true
    @logros[1].iconogrande.opacity = 255
    else  
    @logros[1].iconogrande.opacity = 50
    end

    #Caf 

    if $game_switches[135] == true
    @logros[2].iconogrande.opacity = 255
    else  
    @logros[2].iconogrande.opacity = 50
    end

    #Madera

    if $game_variables[300] >= 15 
    @logros[3].iconogrande.opacity = 255
    else  
    @logros[3].iconogrande.opacity = 50
    end

    #Madera

    if $game_variables[300] >= 50
    @logros[4].iconogrande.opacity = 255
    else  
    @logros[4].iconogrande.opacity = 50
  end  

    #Madera
 
  if $game_variables[300] >= 150
    @logros[5].iconogrande.opacity = 255
    else  
    @logros[5].iconogrande.opacity = 50
  end  

    #Madera

  if $game_variables[300] >= 400
    @logros[6].iconogrande.opacity = 255
    else  
    @logros[6].iconogrande.opacity = 50
  end  

    #Ni a perdida
  
  if $game_switches[703] 
    @logros[7].iconogrande.opacity = 255
    else  
    @logros[7].iconogrande.opacity = 50
  end  

    #Cueva Algoritmo

  if $game_switches[704] 
    @logros[8].iconogrande.opacity = 255
    else  
    @logros[8].iconogrande.opacity = 50
  end  

    #Nota 10
  
  if $game_switches[705] 
    @logros[9].iconogrande.opacity = 255
    else  
    @logros[9].iconogrande.opacity = 50
  end  

    #PeepoClown

  if $game_switches[706] 
    @logros[10].iconogrande.opacity = 255
    else  
    @logros[10].iconogrande.opacity = 50
  end  

    #Arqueologo enamorao
  
  if $game_switches[707] 
    @logros[11].iconogrande.opacity = 255
    else  
    @logros[11].iconogrande.opacity = 50
  end  
  
    #Mondongo

  if $game_switches[708] 
    @logros[12].iconogrande.opacity = 255
    else  
    @logros[12].iconogrande.opacity = 50
  end  
  
    #Majime

  if $game_switches[709] 
    @logros[13].iconogrande.opacity = 255
    else  
    @logros[13].iconogrande.opacity = 50
  end  

    #Celebi  

  if $game_switches[454] 
    @logros[14].iconogrande.opacity = 255
    else  
    @logros[14].iconogrande.opacity = 50
    end  

    #Monta ero F  

  if $game_switches[711] 
    @logros[15].iconogrande.opacity = 255
    else  
    @logros[15].iconogrande.opacity = 50
    end

    #Mimikyu

  if $game_switches[712] 
    @logros[16].iconogrande.opacity = 255
    else  
    @logros[16].iconogrande.opacity = 50
    end   

    #Brenda god

  if $game_switches[713] 
    @logros[17].iconogrande.opacity = 255
    else  
    @logros[17].iconogrande.opacity = 50
    end 

    #Minar 5

  if $game_variables[301] >= 5 
    @logros[18].iconogrande.opacity = 255
    else  
    @logros[18].iconogrande.opacity = 50
    end      

    #Minar 20

  if $game_variables[301] >= 20 
    @logros[19].iconogrande.opacity = 255
    else  
    @logros[19].iconogrande.opacity = 50
    end        

    #Minar 50

  if $game_variables[301] >= 50 
    @logros[20].iconogrande.opacity = 255
    else  
    @logros[20].iconogrande.opacity = 50
    end   

    #Minar 100

  if $game_variables[301] >= 100 
    @logros[21].iconogrande.opacity = 255
    else  
    @logros[21].iconogrande.opacity = 50
    end 

    #Derrota Lluvia / Adri n

  if $game_switches[714] == true
    @logros[22].iconogrande.opacity = 255
    else  
    @logros[22].iconogrande.opacity = 50
    end 

    #Xylon pelota

  if $game_switches[715] == true
    @logros[23].iconogrande.opacity = 255
    else  
    @logros[23].iconogrande.opacity = 50
    end

    #iglesia

  if $game_switches[716] == true
    @logros[24].iconogrande.opacity = 255
    else  
    @logros[24].iconogrande.opacity = 50
    end

    #Hakan

  if $game_switches[717] == true
    @logros[25].iconogrande.opacity = 255
    else  
    @logros[25].iconogrande.opacity = 50
    end

    #Calzoncillos

  if $game_switches[718] == true
    @logros[26].iconogrande.opacity = 255
    else  
    @logros[26].iconogrande.opacity = 50
    end

    #Vegeta

  if $game_switches[725] == true
    @logros[27].iconogrande.opacity = 255
    else  
    @logros[27].iconogrande.opacity = 50
    end

    # Pareja F

  if $game_switches[726] == true
    @logros[28].iconogrande.opacity = 255
    else  
    @logros[28].iconogrande.opacity = 50
    end

    #Brenda y Agapito

  if $game_switches[727] == true
    @logros[29].iconogrande.opacity = 255
    else  
    @logros[29].iconogrande.opacity = 50
    end

    #Shutuber de exito

  if $game_switches[728] == true
    @logros[30].iconogrande.opacity = 255
    else  
    @logros[30].iconogrande.opacity = 50
    end

   # Pokedex 100

  if $game_switches[729] == true
    @logros[31].iconogrande.opacity = 255
    else  
    @logros[31].iconogrande.opacity = 50
    end

   # Pokedex 250

  if $game_switches[730] == true
    @logros[32].iconogrande.opacity = 255
    else  
    @logros[32].iconogrande.opacity = 50
    end

   # Pokedex 500

  if $game_switches[731] == true
    @logros[33].iconogrande.opacity = 255
    else  
    @logros[33].iconogrande.opacity = 50
    end

   # Pokedex 1000

  if $game_switches[732] == true
    @logros[34].iconogrande.opacity = 255
    else  
    @logros[34].iconogrande.opacity = 50
    end

   # 100000 pokedolares

  if $game_switches[733] == true
    @logros[35].iconogrande.opacity = 255
    else  
    @logros[35].iconogrande.opacity = 50
    end

   # 500000 pokedolares

  if $game_switches[734] == true
    @logros[36].iconogrande.opacity = 255
    else  
    @logros[36].iconogrande.opacity = 50
    end

   # 1000000 pokedolares

  if $game_switches[735] == true
    @logros[37].iconogrande.opacity = 255
    else  
    @logros[37].iconogrande.opacity = 50
    end

   # Bagabundo

  if $game_switches[736] == true
    @logros[38].iconogrande.opacity = 255
    else  
    @logros[38].iconogrande.opacity = 50
    end

  if $game_switches[737] == true
    @logros[39].iconogrande.opacity = 255
    else  
    @logros[39].iconogrande.opacity = 50
    end

  if $game_switches[738] == true
    @logros[40].iconogrande.opacity = 255
    else  
    @logros[40].iconogrande.opacity = 50
    end
end 

####################################################################




  def pbUpdate
    pbUpdateSpriteHash(@sprites)
  end
  
  def pbEndScene
    pbFadeOutAndHide(@sprites) { pbUpdate }
    pbDisposeSpriteHash(@sprites)
    @viewport.dispose
  end

def pbCallAchievements
  scene=Pokemon_Achievements_Scene.new
  screen=Pokemon_Achievements.new(scene)
  screen.pbStartScreen
end
 
class Pokemon_Achievements
  def initialize(scene)
    @scene=scene
  end
 
  def pbStartScreen
    @scene.pbStartScene
    @scene.pbLogros
    @scene.pbEndScene
  end
end