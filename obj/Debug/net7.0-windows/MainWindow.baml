   M S B A M L   `   `   `  ����K  GZubna ordinacija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Zubna_ordinacijaZubna_ordinacija  5   	   !    Zubna_ordinacija.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Zubna_ordinacija     5   	     � Title$   Zubna ordinacija - Teodora��5   	   $	��500��6,   $	��900��69   .��5
      � 
�������6  0System.Windows.Controls.Ribbon.RibbonTwoLineText   HasTwoLines$
 True��6'    J� OpacityMask
 �   �.+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridCentralni��5      $��Center=�6.   $��Center=�6K   $
��auto��6f   $
��auto��6s      
IsReadOnly$
 True��6�   
�������   AlternatingRowBackground
 ��İ�   CanUserAddRows$ False��5   T      SelectionUnit$ FullRow=�6k      SelectionMode$ Single=�6�   �� 5   
   $��Center=�6   $	��Top=�62   $��40��6J   $
��auto��6V   	 �� Orientation$	 
Horizontal=�6c   .+�5      �� -   5        
 ��Name$
 btnKorisnici��5      
�������
�������$��	Korisnici��6V   $
��Left=�6j   $	��Top=�6�   $��40��6�   $��75��6�   6�   �� 5      -   5        $
 btnPacijenti��5      
�������
�������$��	Pacijenti��6V   $
��Left=�6j   $	��Top=�6�   $��75��6�   $��40��6�   6�   �� 5      -   5        $
 btnTretmani��5      
�������
�������$��Tretmani��6U   $
��Left=�6h   $	��Top=�6�   $��75��6�   $��40��6�   6�   �� 5      -   5        $
 
btnTermini��5      
�������
�������$��Termini��6T   $
��Left=�6f   $	��Top=�6�   $��75��6�   $��40��6�   6�   �� 5      -   5        $
 btnEvidencije��5      
�������
�������$��
Evidencije��6W   $
��Left=�6l   $	��Top=�6�   $��75��6�   $��40��6�   6�   �� 5      -   5        $
 btnDijagnoze��5      
�������
�������$��	Dijagnoze��6V   $
��Left=�6j   $	��Top=�6�   $��75��6�   $��40��6�   6�   �� 5      -   5        $
 btnOsiguranja��5      
�������
�������$��
Osiguranja��6W   $
��Left=�6l   $	��Top=�6�   $��75��6�   $��40��6�   6�   �� 5      -	   5        $
 	btnRacuni��5      
�������
�������$��Racuni��6S   $
��Left=�6d   $	��Top=�6   $��75��6�   $��40��6�   6�   5      �� 5   
   $��Center=�6   $��Bottom=�62   $��40��6M   $
��auto��6Y   $	 
Horizontal=�6f   .+�5      �� -
   5        $
 btnDodaj��5      
�������
��� d �$��Dodaj��6Y   $
��Left=�6i   $	��Top=�6�   $��75��6�   $��40��6�   6�   �� 5      -   5        $
 	btnIzmeni��5      
�������
��� d �$��Izmeni��6Z   $
��Left=�6k   $	��Top=�6�   $��75��6�   $��40��6�   6�   �� 5      -   5        $
 	btnObrisi��5      
�������
��� d �$��Obrisi��6Z   $
��Left=�6k   $	��Top=�6�   $��75��6�   $��40��6�   6�   5      5      5       