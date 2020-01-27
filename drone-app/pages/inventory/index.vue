<template>
<div>
    <v-layout row wrap px-12 pt-12>
      <v-flex md12>
        <h1>Containers</h1>
      </v-flex>
    </v-layout>

    <v-layout>
      <v-flex md12 pa-5>
      </v-flex>
    </v-layout>

    <v-layout px-12>
      <v-flex md12>
        <v-card class="elevation-1">
          <v-data-table
            :headers="headers"
            :items="containers"
            :items-per-page="15"
            class="elevation-12"
            @click:row="(item) => toView(item)"
          ></v-data-table>
        </v-card>
      </v-flex>
    </v-layout>
  </div>
</template>

<script>
export default {
  data: () => ({
    headers: [
      {
        text: 'Id',
        align: 'left',
        sortable: false,
        value: 'id',
      },
      { text: 'Name', value: 'name' },
      { text: 'Description', value: 'description' },
      { text: 'Serial Number', value: 'serialNumber' }
    ],
    containers: []
  }),
  mounted(){
    this.getContainers()
  },
  methods: {
    getContainers(){
      this.$axios.$get('https://localhost:44367/api/containers').then((result) => {
        this.containers = result;
      }).catch((err) => {
        console.log(err);
      });
    },
    toView(item){
      this.$nuxt.$router.replace({path : '/inventory/view/' + item.id});
    }
  }
}
</script>

<style>

</style>