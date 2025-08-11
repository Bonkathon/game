# Bonk Gochi

## Features

- **Input System** (se o jogador interagir com monstros)
- **Movement System** (controle de movimentação livre)
- **AI/Behavior System** (decisões automáticas, rotina)
- **Health System** (vida, energia, fome, efeitos)
- **UI System** (exibir status do monstro)
- **Save/Load System** (persistência dos monstros e atributos)
- **Spawn System** (criação/instanciação dos monstros)

## Monsters

### States

- **Idle**: comportamento calmo, regeneração de energia/vida.
- **Wander**: movimento aleatório dentro de área segura.
- **Chase**: perseguir objetos ou criaturas (ex: itens, ameaças).
- **Flee**: fugir de perigos ou ameaças.
- **Interact**: estado para quando o jogador está interagindo (alimentar, brincar).
- **FollowPlayer**: seguir o jogador de forma controlada.
- **Rest**: ficar parado para recuperar atributos (fome, energia).
- **Eat**: consumir comida para recuperar fome.
- **Sleep**: descansar para recuperação total.
- **Play**: executar ações de diversão, melhorando humor.
- **Sleep**: descansar para recuperação total.
- **Alert**: estado de atenção, reagindo a estímulos próximos.
- **Dead**: estado final, sem ações possíveis.
