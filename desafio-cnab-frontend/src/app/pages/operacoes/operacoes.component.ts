import { Component } from '@angular/core';
import { Cnab } from 'src/app/shared/models/cnab';
import { CnabService } from 'src/app/shared/services/cnab.service';

@Component({
  selector: 'app-operacoes',
  templateUrl: './operacoes.component.html',
  styleUrls: ['./operacoes.component.scss']
})
export class OperacoesComponent{
  
  operacoes: Cnab[] | undefined;
  
  constructor(private cnabService: CnabService) {}

  getAll(){
    const dataImportacao = '2023-07-17'
    this.cnabService.getAll(dataImportacao).subscribe((resp: Cnab[]) => {
      this.operacoes = resp;
    })
  }
}
  