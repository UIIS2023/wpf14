   M S B A M L   `   `   `  ����K  GZubna ordinacija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Zubna_ordinacija.FormeZubna_ordinacija.Forme  5   	   )    #Zubna_ordinacija.Forme.FrmDijagnoze   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Zubna_ordinacija.Forme     5   	     � Title$  Dodaj/Izmeni dijagnozu��5   	   $	��300��6(   $	��300��65   .��5	      � 
�������.+�5
   
   �� $��Naziv dijagnoze: ��6   $
��Left=�6-   $��	29,30,0,0q�6H   $	��Top=�6[    J� RenderTransformOrigin$ -1.035,-0.927&�6s   �� 5   
   -   5         ��Name$ txtNazivDijagnoze��5      $
��Left=�6-   $��
135,31,0,0q�6H    �� TextWrapping$
 Wrap=�6\   $�� ��6p   $	��Top=�6x   $��23��6�   $	��120��6�   �� 5   
   $��Plan lečenja: ��6   $
��Left=�6*   $��	29,60,0,0q�6E   $	��Top=�6X   $ -1.035,-0.927&�6p   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6%   
�������
��� d �$
��Left=�6i   $��
30,238,0,0q�6�   $��75��6�   $	��Top=�6�   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkazi��6$   
���z���
���  ��$
��Left=�6c   $��180,238,0,0q�6~   $��75��6�   $	��Top=�6�   6�   �� 5   
   -   5        $ txtPlan��5      $
��Left=�6#   $��
135,61,0,0q�6>   $
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $��23��6�   $	��120��6�   �� 5   
   $��
Korisnik: ��6   $
��Left=�6&   $��	29,91,0,0q�6A   $	��Top=�6T   $ -1.035,-0.927&�6l   �� 5   
   -   5         ��Name$ 
cbKorisnik��5      $
��Left=�6'   $��
135,92,0,0q�6B   $	��Top=�6V   $��23��6n   $	��120��6z    �� DisplayMemberPath$
 JMBG��6�    �� SelectedValuePath$ 
korisnikID��6�   �� 5   
   $��
Pacijent: ��6   $
��Left=�6&   $��
29,121,0,0q�6A   $	��Top=�6U   $ -1.035,-0.927&�6m   �� 5   
   -   5        $ 
cbPacijent��5      $
��Left=�6'   $��135,122,0,0q�6B   $	��Top=�6W   $��23��6o   $	��120��6{   $ JMBGPacijenta��6�   $ 
pacijentID��6�   �� 5   
   $��Evidencija: ��6   $
��Left=�6(   $��
29,151,0,0q�6C   $	��Top=�6W   $ -1.035,-0.927&�6o   �� 5   
   -   5        $ cbEvidencija��5      $
��Left=�6)   $��135,152,0,0q�6D   $	��Top=�6Y   $��23��6q   $	��120��6}   $ trenutnoStanjeTokaLecenja��6�   $ evidencijaID��6�   �� 5   
   $��Racun: ��6   $
��Left=�6#   $��
29,181,0,0q�6>   $	��Top=�6R   $ -1.035,-0.927&�6j   �� 5   
   -   5        $ cbRacun��5      $
��Left=�6$   $��135,182,0,0q�6?   $	��Top=�6T   $��23��6l   $	��120��6x   $ 
ukupnaCena��6�   $ racunID��6�   5      5      