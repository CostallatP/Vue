<template>
  <div>
          <titulo texto="Professores" />

    <table>
      <thead>
        <th>Cod.</th>
        <th>nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="Professores.length">
        <tr v-for="(Professor, index) in Professores" :key="index">
          <td>{{ Professor.id }}</td>
          <td>{{ Professor.nome }} {{ Professor.sobrenome }}</td>
          <td>
             3 
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        nenhum Professor encontrado
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from'../_share/Titulo'

export default {
    components:{
Titulo
    },
    data() {
        return {
            Professores:[
                {id:1,nome: 'Miguel'},
                {id:2,nome: 'Paula'},
                {id:3,nome: 'Alex'}
            ]
        }
    },
};
</script>

<style lang="scss" scoped>
</style>