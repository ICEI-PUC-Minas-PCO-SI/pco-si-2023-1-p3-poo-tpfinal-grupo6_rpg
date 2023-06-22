# Introdução

A história se passa em um período de conflito e guerra entre a Terra da Sombra e as Vilas do Tempo Dourado. Antigamente, havia paz entre os povos, mas tudo mudou após a morte do rei Loyor. Seus chefes militares, Artham Kilmer e Zuber Kilmer, descobriram a história das Três Pedras Preciosas de Parthas, que supostamente concediam poder completo sobre o tempo ao guerreiro que as juntasse e as levasse ao topo da Torre de Cadman.

No entanto, Zuber trai Artham e se torna o imperador da Terra da Sombra, obtendo as pedras preciosas. Ele tenta conquistar as Vilas do Tempo Dourado usando monstros, criaturas hipnotizadas e feitiços poderosos. Apesar dos esforços dos magos, guerreiros e arqueiros das terras douradas, todos falharam em derrotar Zuber e recuperar as pedras preciosas.

Há rumores de que uma carta na Floresta Mística da Escuridão contém informações sobre como derrotar Zuber, mas ninguém conseguiu encontrá-la até o momento. A história retrata a luta dos heróis para derrubar o imperador e trazer paz de volta à região.

## Explicação Detalhada do Desenvolvimento (Arquitetura do Projeto)

**⨠ DESENVOLVIMENTO EM C# (CONSOLE)**

Foi seguido a seguinte estrutura para o projeto do jogo RPG 

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/be7ac1ab-3058-4511-80e5-49f5241f6e24)


Onde que, cada pasta contem certos tipos classes relacionadas, estas pastas foi definidas como
Habilidades -> Irá conter todas as habilidades criadas, por se tratar de uma grande variedade de classes distintas uma da outra, foi melhor optado colocar em uma pasta apenas disto

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/4e7d284e-1619-4c6f-8bf8-e0d877578b04)


Interface -> A pasta de interface, irá conter todas as interfaces utilizadas

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/e7b42ff8-0e56-439c-8ed0-dd2efda838a1)


Itens -> Seguiu a mesma logica da pasta de habilidades, por se tratar de muitos itens, foi preferido criar uma pasta para organiza-los

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/58297d33-27ea-4941-a928-98ca1d2b473a)


Models -> A pasta models irá conter todas as entidades utilizadas no projeto, desde as classes base/abstratas até suas classes mais especificas

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/916c44b4-f89a-476a-9f80-2a736b3b5601)

  
View -> Na pasta view, foi colocado as regras atribuídas ao jogo, contendo duas classes apenas, uma representando os atributos e a outra representando todas as operações/funcionalidades do jogo...

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/5cad086f-307a-4602-bb85-c07fb404e069)


* Habilidades e atributos

A Classe Habilidade e a interface Istatus representam a base de todo personagem, onde que, serão definidos atributos de cada personagem e as habilidades dos mesmos.

Exemplo de uma habilidade:

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/ec4a1c65-92b9-4a9c-aa98-cfdbc05ce8ae)


Obs: Todas as habilidades seguem este mesmo padrão, mudando apenas os valores
Definição de atributos:

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/95ec643d-cfd4-4dc7-be0e-1dcd3680b9ab)


* Classe Personagem

A classe personagem foi uma das principais de todo projeto, onde nela, foi criado uma classe abstrata de personagem

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/bf557edf-2a4d-4597-857c-56e14f710108)


E apartir dela, foi criado outras classes, tais como PersonagemMonstro, PersonagemJogador, onde que, cada um possuía seus comportamentos alterados baseado em cada uma:

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/c3fdf0db-1fc8-45e1-89d3-7b0e9be212b3)


![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/e2314933-71ca-47f1-8c71-59a99e667ae6)


Ambas Herdam de Personagem e também, possuem um contrato com a interface IStatus, onde nela contem a assinatura de Habilidades e Atributos:

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/1487a2c9-f517-459d-9fa5-e4033d1b1241)


Baseado em suas classes, foram criados as classes do jogador, tais como GUERREIRO, ASSASSINO e MAGO, onde que, cada um teria um construtor baseado em seu status inicial e um método de LevelUP() diferente de um para outro

Exemplo da classe guerreiro:

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/0c3c1f51-5b62-456a-800c-edda9cb844e5)


Obs: as outras classes são praticamente a mesma coisa do guerreiro, mudando apenas os valores...

* Personagem Monstro

Nesta classe, tivemos a ideia de gerar todas as criaturas encontradas de forma randômica, desde seu nível, natureza, nome, nível, status e habilidades....
A classe contem apenas um único construtor, onde que, a partir dele, foi gerado todos os status do monstro

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/e24b4d80-74ba-4287-abeb-b56d8e04848e)


Natureza -> A natureza basicamente é o tipo da criatura que irá ser gerada
Tier -> É o tier do monstro gerado, indo de 1 (mais fraco) a 4(mais forte) e que, tem uma chance menor de ser gerado a cada tier acima...
Nome -> O nome é gerado de forma random baseado em listas
Nivel -> É o nível que o monstro irá nascer, o nível é baseado no nível do jogador, para equilibrar o jogo
MaxHp -> É o Hp que o inimigo irá conter
Atk -> É o ataque base do monstro gerado
XP -> É o xp gerado baseado no Tier derrotado
Habilidade -> Vai ser as habilidades que o monstro irá nascer, cada habilidade possui um Nivel, quanto maior o Tier, maior o nível da habilidade gerada no monstro
Atributo -> Definindo os valores

* Itens

Todos os itens segue uma hierarquia semelhante ao personagem, onde que, existe uma classe base abstrata de Item

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/e4793199-ad10-47b1-9092-8db4b3dc5546)


E, apartir dela, foram gerados os tipos de itens, sendo ItemConsumivel e ItemEquipavel com base nisto, cada um implementou seus próprios métodos e regra de implementação:

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/5d9eac9f-b12c-4e67-af16-f93cd7339a8a)

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/4ccb3f58-ea6c-496a-b4d5-c776f27680d2)


Baseado nestas classes, são gerados os itens respectivos de cada tipo, segue abaixo um exemplo de ItemEquipavel e ItemConsumivel

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/faefffd9-4ae1-4010-8e28-8c4b6cfa79bb)

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/78581201-1f0d-4e8c-b9de-2fdb9447632e)


* Classe Operações

Nesta classe estática, foi definida toda a logica do jogo, sendo o coração de todo o sistema, segue abaixo a classe como um todo 


![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/3a57b43c-3795-4e2a-9fea-fdce16cbddc2)


Foi pensado ao máximo maximizar a otimização e seguir as boas praticas para manter um jogo possível a expansão futuramente.

O projeto teve com foco os seguintes pontos:
Linq, Coleções, Herança, Abstração, Polimorfismo, Listas, Princípios SOLID, Delegate, Reflection, entre outros...

**⨠ DESENVOLVIMENTO REALIZADO NA UNITY**

Classe Padrão da Unity que permite associar scripts a objetos dentro do jogo.

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/fafdf384-2960-40de-a2ef-66c77d15708a)


Essa classe faz com que seja possível interagir com os NPCs existentes no Mapa. Assim que o player chega no alcance de colisão do NPC e pressiona um botão ele chama a Classe DialogoManager.

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/2aea4dcd-e1da-4e6d-bab4-0fe6b3c11e74)


Algum NPC chama a função ComecarConversa e com isso o Diálogo é iniciado ligando a interface de conversa e também o player não se move. Quando a interface liga, ela verifica se as frases de diálogo já acabaram. Se acabaram, ele chama o Encerrar que desliga a interface e volta o player ao jogo.

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/68f81681-ab97-4f0a-8b1a-efcb5360f73c)

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/b1058870-809e-4773-901a-129b39b433f3)


Possibilita a movimentação do player utilizando RigidBody2D, que é uma física que a Unity utiliza.
![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/25c834a0-f1eb-4abd-803f-35b18aea12ed)


Criada para servir de base para todos itens do jogo onde é definido descrição, se é uma arma, seus valores, imagem e se está em algum personagem
![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/7dd01ead-78c8-4841-b63e-458e8fbcbe50)



Esse é nosso objeto que guarda nossos itens e o xp e persiste entre todas as vezes que o personagem morre e o jogo reseta.


![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/660d7a9d-fdd0-4fa4-a247-f4a0fa542a4b)

![image](https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2023-1-p3-poo-tpfinal-grupo6_rpg/assets/101759330/5208947e-f788-48c1-8333-bfce91c67fea)


**LINK DE ACESSO PARA DOCUMENTO**

https://docs.google.com/document/d/1dnMraV338FfeSh57Wy89srRsf2dD6p3ixJvwHHkU5Lg/edit?usp=sharing

## Objetivos

Como dito anteriormente, nosso jogo tem como objetivo conceder diversão ao jogador através de uma experiência onde suas decisões causam impacto no progresso da história, sendo assim o jogador pode escolher como trilhar sua própria aventura.

Podemos destacar os seguintes objetivos específicos:

* Mundo Explorável
* Missões
* Habilidades ao Subir de Nível
* Diversos Monstros e um Chefe Final

## Público-Alvo

Nosso jogo busca proporcionar uma experiência única para os entusiastas da categoria dos jogos RPG e ao mesmo tempo atender o público do qual gosto de jogos em geral independente da faixa etária.

A partir dos dados pode se extrair algum dos grupos de:

* Amantes de Jogos do Estilo RPG
* Público em Geral de Jogos (que procuram um um jogo com uma nova experiência)
* Qualquer Faixa Etária (Por ser um jogo com uma jogabilidade simples)
