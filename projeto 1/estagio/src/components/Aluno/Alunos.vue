<template>
  <div>
    <titulo :texto="professorid != undefined?      'Professor: ' + professor.nome : 'Todos os Alunos'" />
    <div v-if="professorid !=undefined">
      <input
        type="text"
        placeholder="Nome do Aluno"
        v-model="nome"
        @keyup.enter="addAluno()"
      />
      <button class="btn btnInput" @click="addAluno()">adicionar</button>
    </div>

    <table>
      <thead>
        <th>mat.</th>
        <th>nome</th>
        <th>opções</th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(aluno, index) in alunos" :key="index">
          <td class="colPequeno">{{ aluno.id }}</td>
         
            <router-link :to="`/alunoDetalhe/${aluno.id}`" tag="td" style="cursor: pointer">
            {{ aluno.nome }} {{ aluno.sobrenome }}


            </router-link>
          <td class="colPequeno">
            <button class="btn btn_Danger" @click="remover(aluno)">
              remover
            </button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3" style="text-align: center"> <h5>nenhum Aluno encontrado</h5></td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo.vue";

export default {
  components: {
    Titulo,
  },
  data() {
    return {
      titulo: "Aluno",
      professorid: this.$route.params.prof_id,
      professor:{
      },
      nome: "",
      alunos: []
    };
  },
  created() {
    if(this.professorid){
      this.carregarProfessores();
      this.$http
      .get(`http://localhost:5000/api/aluno/ByProfessor/${this.professorid}`)
      .then((res) => res.json())
      .then((alunos) => (this.alunos = alunos));
    }else{
      this.$http
      .get("http://localhost:5000/api/aluno")
      .then((res) => res.json())
      .then((alunos) => (this.alunos = alunos));
    }
  },
  props: {},
  methods: {
    addAluno() {
      let _aluno = {
        nome: this.nome,
        sobrenome: "",
        dataNasc:"",
        professorid: this.professor.id

        };
      

      this.$http
        .post("http://localhost:5000/api/aluno", _aluno)
        .then((res) => res.json())
        .then((aluno) => {
          this.alunos.push(aluno);
          this.nome = "";
        
        });
    },
    remover(aluno) {
      this.$http.delete(`http://localhost:5000/api/aluno/${aluno.id}`).then(() => {
        let indice = this.alunos.indexOf(aluno);
        this.alunos.splice(indice, 1);
      });
    },
     carregarProfessores() {
      this.$http
        .get("http://localhost:5000/api/professor/"+ this.professorid)
        .then(res => res.json())
        .then(professor => {
          this.professor = professor
        });
    }
  },
};
</script>

<style scoped>
input {
  width: calc(100% - 192px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}
.btnInput {
  width: 150px;
  display: inline;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  background-color: rgb(116, 115, 115);
}
.btnInput:hover {
  padding: 20px;
  margin: 0px;
  border: 0px;
}
</style>
