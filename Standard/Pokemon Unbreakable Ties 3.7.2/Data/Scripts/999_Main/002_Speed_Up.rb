# PARA CONTROLAR Y QUITAR SPEED, EN SCRIPTS: ChangeSpeed.new.pbChangeSpeed(id)

SPEEDUP_STAGES = [1,2]
$GameSpeed = 0
$frame = 0
$CanToggle = true
$isSpeedDesactivated = false



module Input
  #def self.isDesactivated
     #if ($game_switches[996])
	#return $isSpeedDesactivated  = true
     #else
	#return $isSpeedDesactivated  = false
     #end
   #end


  def self.update
    update_KGC_ScreenCapture
    if trigger?(Input::F8)
      pbScreenCapture
    end
    if $CanToggle && trigger?(Input::AUX1) #remap your Q button on the F1 screen to change your speedup switch
      $GameSpeed += 1
      $GameSpeed = 0 if $GameSpeed >= SPEEDUP_STAGES.size
      
      #PARA CONTROLAR CIERTAS ESCENAS QUE NO QUIERO TURBO
      #if (isDesactivated)
	#$GameSpeed = 0
      #end

    end
  end
end


module Graphics
  class << Graphics
    alias fast_forward_update update
  end

  def self.update
    #if (!$isSpeedDesactivated)
      $frame += 1
    #else
      #$frame = 0
      #$GameSpeed = 0
    #end

    return unless $frame % SPEEDUP_STAGES[$GameSpeed] == 0
    fast_forward_update
    $frame = 0
  end
end


class ChangeSpeed
  def pbChangeSpeed(id)
    $GameSpeed = id
    $frame = id
    $isSpeedDesactivated = true
  end
end
  
