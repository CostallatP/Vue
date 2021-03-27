<template>
    <div class="barraTop">
<nav class="marginPrincipal">
    <router-link to ="/professores">Professor</router-link>
    <router-link to ="/alunos">Alunos</router-link>
    <router-link to ="/sobre">Sobre</router-link>
</nav>
    </div>
</template>

<script>
    export default {
        
    }
</script>

<style scoped>
.barraTop{
background-color: rgb(230, 230, 230) ;
}


.marginPrincipal{


}
nav{
    padding: 20px 20px 20px 0px;
}
nav a{
    text-decoration: none;
    background-color: #fff;
    padding: 10px;
    border-radius: 3px;
    color: rgb(0, 110, 255);
    font-weight: bold;
    margin-right: 15px;

}

nav .router-link-exact-active{
    background-color: rgb(160, 160, 160);
    color: white;
}
</style>